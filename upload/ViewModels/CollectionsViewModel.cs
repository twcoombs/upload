using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using upload.Models;

namespace upload.ViewModels
{
    public class CollectionsViewModel
    {
        public IEnumerable<Collection> Collection { get; set; }

    }
}