using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Labb1.Models
{
    public class AlbumModel
    {
        [Key]
        public Guid AlbumID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<AlbumImages> AlbumListOfImages { get; set; }

        //public List<Comments> Comments = new List<Comments>();
        //public List<ModelGallery> AlbumListOfImages = new List<ModelGallery>();

    }
}
    