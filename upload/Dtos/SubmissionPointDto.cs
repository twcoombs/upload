using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using upload.Models;

namespace upload.Dtos
{
    public class SubmissionPointDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Attribute { get; set; }
        public PointType PointType { get; set; }
        [Required]
        public int PointTypeId { get; set; }
        public string Comments { get; set; }
        public CollectionPoint CollectionPoint { get; set; }
        public int CollectionPointId { get; set; }
        public Submission Submission { get; set; }
        public int SubmissionId { get; set; }
    }
}