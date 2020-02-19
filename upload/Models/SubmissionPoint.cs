using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace upload.Models
{
    public class SubmissionPoint
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Attribute { get; set; }
        [Display(Name = "Point Meta-data")]
        public PointType PointType { get; set; }
        [Required]
        [Display(Name = "Point Meta-data")]
        public int PointTypeId { get; set; }
        public string Comments { get; set; }
        [Display(Name = "Mapping Point")]
        public CollectionPoint CollectionPoint { get; set; }
        [Display(Name = "Mapping Point")]
        public int CollectionPointId { get; set; }
        public Submission Submission { get; set; }
        public int SubmissionId { get; set; }
    }
}