using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyDataForLabb1.Models
{
    public class ModelGallery
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Comments> ImageComments { get; set; }
        public AlbumModel AlbumID { get; set; }
    }
}
