using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using upload.Models;
using upload.ViewModels;

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
        public ActionResult Create(Collection collection)
        {
            _context.Collection.Add(collection);
            _context.SaveChanges();

            return RedirectToAction("Index", "Collection");
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
        public ActionResult Collection(int id)
        {
            var collection = _context.Collection.SingleOrDefault(c => c.Id == id);

            var collectionPoints = _context.CollectionPoint.Where(cp => cp.CollectionId == id).ToList();

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

            foreach(var collectionPoint in viewModel.CollectionPoints)
            {
                var collectionPointDB = _context.CollectionPoint.Single(c => c.Id == collectionPoint.Id);

                collectionPointDB.Attribute = collectionPoint.Attribute;
                collectionPointDB.PointTypeId = collectionPoint.PointTypeId;
                collectionPointDB.Comments = collectionPoint.Comments;

            }

            _context.SaveChanges();

            //redirect to Collection
            return RedirectToAction("Index", "Collection");
        }
    }
}