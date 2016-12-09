using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Labb1.Models
{
    public class AlbumImages
    {
        
        [Key]
        public Guid Id_ { get; set; }
        public ModelGallery Id { get; set; }
        public virtual ICollection<ModelGallery> Images { get; set; }
        public AlbumModel AlbumID { get; set; }
        public virtual ICollection<AlbumModel> Albums { get; set; }
        //public List<ModelGallery> Images { get; set; }
        //public List<AlbumModel> Albums { get; set; }
    }
}