using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using upload.Models;

namespace upload.Dtos
{
    public class CollectionDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string DataSteward { get; set; }
        public CollectionFileType CollectionFileType { get; set; }
        public byte CollectionFileTypeId { get; set; }
        public int Authorised { get; set; }
        public string FilePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase TemplateFile { get; set; }
    }
}