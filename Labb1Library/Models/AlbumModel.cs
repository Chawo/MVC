using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Labb1Library
{
    class AlbumModel
    {
        [Key]
        public Guid AlbumID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<ModelGallery> AlbumListOfImages { get; set; }
    }
}
