using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDataForLabb1.Models
{
    public class AlbumImages
    {
        //Foreign key for Standard
        public Guid AlbumID { get; set; }

        [ForeignKey("AlbumID")]
        public AlbumModel Album { get; set; }

        //Foreign key for Standard
        public Guid Id { get; set; }

        [ForeignKey("Id")]
        public ModelGallery Image { get; set; }

        public virtual ICollection<AlbumModel> Albums { get; set; }
        public virtual ICollection<ModelGallery> Images { get; set; }

    }
}
