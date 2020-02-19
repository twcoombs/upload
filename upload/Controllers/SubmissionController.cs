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
    public class SubmissionController : Controller
    {
        private ApplicationDbContext _context;
        public SubmissionController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Submission
        public ActionResult Index()
        {
            var submissions = _context.Submission.Include(c => c.CollectionFileType).Include(c => c.Collection).ToList();

            return View(submissions);

        }

        public ActionResult New()
        {
            var fileExtensionTypes = _context.CollectionFileType.ToList();
            var collections = _context.Collection.ToList();
            

            var viewModel = new NewSubmissionViewModel
            {
                CollectionFileTypes = fileExtensionTypes,
                Collection = collections
            };

            return View(viewModel);
        }

        public ActionResult Submission(int id, string newSubmissionList)
        {
            var submission = _context.Submission.Include(c => c.Collection).SingleOrDefault(c => c.Id == id);

            var submissionPoints = _context.SubmissionPoint.Where(sp => sp.SubmissionId == id).ToList();

            var collectionPoints = _context.CollectionPoint.Where(cp => cp.CollectionId == submission.CollectionId).ToList();

            var pointTypes = _context.PointType.ToList();

            if (newSubmissionList != null)
            {
                submissionPoints.Clear();

                List<string> model = JsonConvert.DeserializeObject<List<string>>(newSubmissionList);

                foreach (var list in model)
                {
                    submissionPoints.Add(new SubmissionPoint { Attribute = list, PointTypeId = collectionPoints[0].Id, Comments = "", SubmissionId = id });
                }

            }

            if (submission == null)
                return HttpNotFound();

            if (submissionPoints == null)
                return HttpNotFound();

            var viewModel = new SubmissionAndPointViewModel
            {
                Submission = submission,
                SubmissionPoints = submissionPoints,
                CollectionPoints = collectionPoints,
                PointTypes = pointTypes
            };

            return View(viewModel);

        }


    public ActionResult SaveSubmissionPoint(SubmissionAndPointViewModel viewModel)
    {
        foreach (SubmissionPoint submissionPoint in viewModel.SubmissionPoints)
        {

            if (submissionPoint.Id == 0)
            {
                _context.SubmissionPoint.Add(submissionPoint);
            }
            else
            {
                var collectionPointDB = _context.SubmissionPoint.Single(c => c.Id == submissionPoint.Id);

                collectionPointDB.Attribute = submissionPoint.Attribute;
                collectionPointDB.PointTypeId = submissionPoint.PointTypeId;
                collectionPointDB.Comments = submissionPoint.Comments;
                collectionPointDB.CollectionPointId = submissionPoint.CollectionPointId;
                }
        }

        _context.SaveChanges();

        TempData["message"] = "You successfully updated the Submission " + viewModel.Submission.Name + " with the suggested changes";
        //redirect to Collection
        return RedirectToAction("Index", "Submission");
    }

        [HttpPost]
        public ActionResult CreateXML(Submission submission)
        {
            _context.Submission.Add(submission);
            _context.SaveChanges();

            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(submission.TemplateFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(submission.TemplateFile.FileName);

            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            // If file with same name exists delete it
            if (System.IO.File.Exists(FileName))
            {
                System.IO.File.Delete(FileName);
            }

            //Get Upload path from Web.Config file AppSettings.  
            string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

            System.IO.Directory.CreateDirectory(UploadPath + "Submissions\\" + submission.Id + "\\Definition\\");

            //Its Create complete path to store in server.  
            submission.FilePath = UploadPath + "Submissions\\" + submission.Id + "\\Definition\\" + FileName;

            Debug.WriteLine(submission.FilePath);

            //To copy and save file into server.  
            submission.TemplateFile.SaveAs(submission.FilePath);

            submission.Authorised = 0;

            
            List<string> headers = new List<string>();

            if (submission.CollectionFileTypeId == 3)
            {
                CSVRead csv = new CSVRead();

                headers = csv.readCSV(submission.FilePath);

                foreach (var temp in headers)
                {
                    TempData["message"] = TempData["message"] + "||" + temp;
                }
            }
            else if (submission.CollectionFileTypeId == 4)
            {

                XMLRead xml = new XMLRead();

                headers = xml.readXML(submission.FilePath);
            }

            TempData["message"] = "This Submission Has Been Created From Uploaded File: " + FileName + " If you do not click submit to save Submission Points before exiting this screen they will be lost";

            _context.SaveChanges();

            return RedirectToAction("Submission", new RouteValueDictionary(
            new { controller = "Submission", action = "Submission", newSubmissionList = JsonConvert.SerializeObject(headers.ToList()), id = submission.Id }));
        }


    }
}
