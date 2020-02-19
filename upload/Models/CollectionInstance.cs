using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace upload.Models
{
    public class CollectionInstance
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public Collection Collection { get; set; }
        public int CollectionId { get; set; }
    }
    
}