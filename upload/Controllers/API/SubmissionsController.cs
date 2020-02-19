using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using upload.Models;
using System.Data.Entity;
using upload.Dtos;
using AutoMapper;

namespace upload.Controllers.API
{
    public class SubmissionsController : ApiController
    {
        public ApplicationDbContext _context;

        public SubmissionsController()
        {
            _context = new ApplicationDbContext();
        }

        public Submission GetSubmissionPoints(int id)
        {
            return _context.Submission.SingleOrDefault(s => s.Id == id);
        }

        [HttpDelete]
        public void DeleteSubmission(int id)
        {
            var submissionInDb = _context.Submission.SingleOrDefault(s => s.Id == id);

            var submissionPointInDb = _context.SubmissionPoint.Where(sp => sp.SubmissionId == id).ToList();

            if (submissionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            foreach(var submissionPoint in submissionPointInDb)
            {
                _context.SubmissionPoint.Remove(submissionPoint);
            }
            _context.Submission.Remove(submissionInDb);
            _context.SaveChanges();
        }
    }
}
