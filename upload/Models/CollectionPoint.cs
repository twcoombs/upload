﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace upload.Models
{
    public class CollectionPoint
    {
        [Required]
        [Display(Name = "Ingestion Data Point")]
        public int Id { get; set; }
        [Display(Name = "Ingestion Data Point")]
        [Required]
        public string Attribute { get; set; }
        public PointType PointType { get; set; }
        [Required]
        [Display(Name = "Point Data Type")]
        public int PointTypeId { get; set; }
        public string Comments { get; set; }
        public Collection Collection{ get; set; }
        public int CollectionId { get; set; }
    }
}