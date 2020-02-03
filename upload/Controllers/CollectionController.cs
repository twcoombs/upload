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
        // GET: Collection
        public ActionResult Collection(int id)
        {
            var collection = new Collection() { Name = "Collection " + id };
            var collectionPoints = new List<CollectionPoint>
            {
                new CollectionPoint {LineKey=1, Set =1, Attribute = "ID", DataType = "Integer", Comments = "Test Point One"},
                new CollectionPoint {LineKey=1, Set =1, Attribute = "Name", DataType = "String", Comments = "Test Point One"},
                new CollectionPoint {LineKey=1, Set =1, Attribute = "Value", DataType = "Integer", Comments = "Test Point One"}
            };

            var viewModel = new CollectionAndPointViewModel
            {
                Collection = collection,
                CollectionPoints = collectionPoints
            };

            return View(viewModel);
        }
    }
}