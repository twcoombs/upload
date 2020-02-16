using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upload.Models
{
    public class Collection
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Collection Name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Data Steward")]
        public string DataSteward { get; set; }
        public CollectionFileType CollectionFileType { get; set; }
        public byte CollectionFileTypeId { get; set; }
        public int Authorised { get; set; }
        [Display(Name = "Upload File")]
        public string FilePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase TemplateFile { get; set; }

    }
}