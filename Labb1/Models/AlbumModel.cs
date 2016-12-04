using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb1.Models
{
    public class AlbumModel
    {
        public Guid AlbumID { get; set; }
        public string Name { get ; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Comments> Comments { get; set; }
        public List<ModelGallery> Images { get; set; }

    }
}