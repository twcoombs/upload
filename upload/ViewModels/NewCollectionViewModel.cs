using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using upload.Models;

namespace upload.ViewModels
{
    public class NewCollectionViewModel
    {
        public Collection Collection { get; set; }
        public IEnumerable<CollectionFileType> CollectionFileTypes { get; set; }

    }
}