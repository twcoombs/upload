using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace upload.Models
{
    public class CollectionPoint
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int LineKey { get; set; }
        public int Set { get; set; }
        [Required]
        public string Attribute { get; set; }
        [Required]
        public string DataType { get; set; }
        public string Comments { get; set; }
        public Collection Collection{ get; set; }
        public int CollectionId { get; set; }
    }
}