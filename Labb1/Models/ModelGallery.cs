using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb1.Models
{
    public class ModelGallery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<Comments> ImageComments { get; set; }

        public IEnumerable<string> Image { get; set; }

    }
}