using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace upload.Models
{
    public class Collection
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public CollectionFileType CollectionFileType { get; set; }
        public byte CollectionFileTypeId { get; set; }

    }
}