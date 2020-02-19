using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using upload.Models;

namespace upload.Dtos
{
    public class CollectionPointDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Attribute { get; set; }
        public PointType PointType { get; set; }
        [Required]
        public int PointTypeId { get; set; }
        public string Comments { get; set; }
        public Collection Collection { get; set; }
        public int CollectionId { get; set; }
    }
}