using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyDataForLabb1.Models
{
    public class AlbumImages
    {
        [Key]
        public Guid Id { get; set; }
        public virtual ICollection<ModelGallery> Images { get; set; }
        public virtual ICollection<AlbumModel> Albums { get; set; }
    }
}
