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

        public List<Comments> ImageComments { get; set; }
        public Guid AlbumID { get; set; }

        public IEnumerable<string> Images { get; set; }

    }
}