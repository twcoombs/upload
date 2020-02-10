using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using upload.Models;

namespace upload.ViewModels
{
    public class CollectionAndPointViewModel
    {
        public Collection Collection { get; set; }
        public List<CollectionPoint> CollectionPoints { get; set; }
        public List<PointType> PointTypes { get; set; }
    }
}