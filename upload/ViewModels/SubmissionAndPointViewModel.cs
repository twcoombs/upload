using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using upload.Models;

namespace upload.ViewModels
{
    public class SubmissionAndPointViewModel
    {
        public Submission Submission { get; set; }
        public List<SubmissionPoint> SubmissionPoints { get; set; }
        public List<PointType> PointTypes { get; set; }
        public List<CollectionPoint> CollectionPoints { get; set; }
    }
}