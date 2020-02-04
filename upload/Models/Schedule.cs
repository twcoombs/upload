using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace upload.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ScheduleType ScheduleType { get; set; }
        public int ScheduleTypeId { get; set; }


    }
}