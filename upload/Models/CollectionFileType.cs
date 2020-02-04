using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace upload.Models
{
    public class CollectionFileType
    {
        public byte Id { get; set; }
        [Display(Name = "File Type")]
        public string FileType { get; set; }
        [Display(Name = "File Extension")]
        public string FileExtension { get; set; }
    }
}