using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using upload.Models;
using upload.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Configuration;
using upload.Classes;
using System.Web.Routing;
using System.Diagnostics;
using Newtonsoft.Json;

namespace upload.Controllers
{
    public class CollectionController : Controller
    {
        private ApplicationDbContext _context;
        public CollectionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var fileExtensionTypes = _context.CollectionFileType.ToList();

            var viewModel = new NewCollectionViewModel
            {
                CollectionFileTypes = fileExtensionTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult NewPoints(int id)
        {
            var collection = _context.Collection.SingleOrDefault(c => c.Id == id);

            var collectionPoints = _context.CollectionPoint.Where(cp => cp.CollectionId == id).ToList();

            if (collection == null)
                return HttpNotFound();

            if (collectionPoints == null)
                return HttpNotFound();

            var viewModel = new CollectionAndPointViewModel
            {
                Collection = collection,
                CollectionPoints = collectionPoints
            };

            return View(viewModel);
        }

        public ViewResult Index()
        {
            var collections = _context.Collection.Include(c => c.CollectionFileType).ToList();

            return View(collections);
        }


        public ActionResult Details(int id)
        {
            var collection = _context.Collection.SingleOrDefault(c => c.Id == id);

            if (collection == null)
                return HttpNotFound();

            return View(collection);
        }

        //[HttpPost]
        public ActionResult Collection(int id, string newCollectionList)
        {
            var collection = _context.Collection.SingleOrDefault(c => c.Id == id);

            var collectionPoints = _context.CollectionPoint.Where(cp => cp.CollectionId == id).ToList();

            if(newCollectionList != null)
            {
                collectionPoints.Clear();

                List<string> model = JsonConvert.DeserializeObject<List<string>>(newCollectionList);

                foreach (var list in model)
                {
                        collectionPoints.Add(new CollectionPoint { Attribute = list, PointTypeId = 1, Comments = "", CollectionId = id });
                }

            }

            var pointTypes = _context.PointType.ToList();

            if (collection == null)
                return HttpNotFound();

            if (collectionPoints == null)
                return HttpNotFound();

            var viewModel = new CollectionAndPointViewModel
            {
                Collection = collection,
                CollectionPoints = collectionPoints,
                PointTypes = pointTypes
            };

            return View(viewModel);
        }

        //[HttpPost]
        public ActionResult SaveCollectionPoint(CollectionAndPointViewModel viewModel)
        {
            foreach(CollectionPoint collectionPoint in viewModel.CollectionPoints) {

                if (collectionPoint.Id == 0)
                {
                    _context.CollectionPoint.Add(collectionPoint);
                }
                else
                {
                    var collectionPointDB = _context.CollectionPoint.Single(c => c.Id == collectionPoint.Id);

                    collectionPointDB.Attribute = collectionPoint.Attribute;
                    collectionPointDB.PointTypeId = collectionPoint.PointTypeId;
                    collectionPointDB.Comments = collectionPoint.Comments;
                }
            }

            _context.SaveChanges();

            TempData["message"] = "You successfully updated the ingestion " + viewModel.Collection.Name + " with the suggested changes";
            //redirect to Collection
            return RedirectToAction("Index", "Collection");
        }

        [HttpPost]
        public ActionResult Create(Collection collection)
        {
            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(collection.TemplateFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(collection.TemplateFile.FileName);

            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            // If file with same name exists delete it
            if (System.IO.File.Exists(FileName))
            {
                System.IO.File.Delete(FileName);
            }

            //Get Upload path from Web.Config file AppSettings.  
            string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

            //Its Create complete path to store in server.  
            collection.FilePath = UploadPath + FileName;

            //To copy and save file into server.  
            collection.TemplateFile.SaveAs(collection.FilePath);

            collection.Authorised = 0;

            _context.Collection.Add(collection);
            _context.SaveChanges();

            CSVRead csv = new CSVRead();

            List<string> headers = csv.readCSV(collection.FilePath);

            TempData["message"] = "This Collection Has Been Created From Uploaded File: " + FileName + " If you do not click submit to save Collection Points before exiting this screen they will be lost";

            return RedirectToAction("Collection", new RouteValueDictionary(
            new { controller = "Collection", action = "Collection", newCollectionList = JsonConvert.SerializeObject(headers.ToList()), id = collection.Id}));
        }

    }
}