using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Labb1.Models
{
    public class ModelGallery
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime dateAdded { get; set; }

        public virtual ICollection<Comments> ImageComments { get; set; }
        public AlbumModel AlbumID { get; set; } 
    }
}