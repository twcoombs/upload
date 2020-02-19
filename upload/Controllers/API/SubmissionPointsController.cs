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
    public class SubmissionPointsController : ApiController
    {
        public ApplicationDbContext _context;

        public SubmissionPointsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET/Api/Submissions
        public IEnumerable<SubmissionPointDto> GetSubmissionPoints()
        {
            return _context.SubmissionPoint.Include(s => s.CollectionPoint).Include(s => s.Submission).Include(s => s.PointType).ToList().Select(Mapper.Map<SubmissionPoint, SubmissionPointDto>);
        }

        public SubmissionPointDto GetSubmissionPoints(int id)
        {
            var submissionPoint = _context.SubmissionPoint.Include(s => s.CollectionPoint).Include(s => s.Submission).Include(s => s.PointType).SingleOrDefault(s => s.Id == id);

            if (submissionPoint == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<SubmissionPoint, SubmissionPointDto>(submissionPoint);

        }

        public void DeleteSubmissionPoint(int id)
        {
            var submissionPointInDb = _context.SubmissionPoint.SingleOrDefault(s => s.Id == id);

            if (submissionPointInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.SubmissionPoint.Remove(submissionPointInDb);
            _context.SaveChanges();
        }
    }
}
