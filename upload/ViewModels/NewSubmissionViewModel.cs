using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using upload.Models;

namespace upload.ViewModels
{
    public class NewSubmissionViewModel
    {
        public Submission Submission { get; set; }
        public IEnumerable<CollectionFileType> CollectionFileTypes { get; set; }

        public IEnumerable<Collection> Collection { get; set; }

    }
}