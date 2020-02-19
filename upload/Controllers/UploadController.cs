using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using upload.Models;
using upload.ViewModels;

namespace upload.Controllers
{
    public class UploadController : Controller
    {
        private ApplicationDbContext _context;
        public UploadController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Upload
        public ActionResult Index()
        {
            var collections = _context.Collection.ToList();

            var viewModel = new CollectionsViewModel
            {
                Collection = collections
            };


            return View(viewModel);
        }


        public ActionResult CollectionRead (Collection collection)
        {


            return RedirectToAction("Upload", "SubmissionSelection");

        }

    }
}