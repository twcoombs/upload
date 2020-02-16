using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace upload.Models
{
    public class Submission
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Submission Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Parent Collection")]
        public Collection Collection { get; set; }
        [Display(Name = "Parent Collection")]
        public int CollectionId { get; set; }
        public CollectionFileType CollectionFileType { get; set; }
        [Display(Name = "Submission Format")]
        public byte CollectionFileTypeId { get; set; }
    }
}