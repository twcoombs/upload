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
            var submissions = _context.Submission.Include(c => c.Collection).ToList();

            return View(submissions);

        }
    }
}