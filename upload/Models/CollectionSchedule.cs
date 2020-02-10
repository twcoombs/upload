using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace upload.Models
{
    public class CollectionSchedule
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public CollectionScheduleType CollectionScheduleType { get; set; }
        public int CollectionScheduleTypeId { get; set; }


    }
}