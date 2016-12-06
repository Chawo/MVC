using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Library
{
    class AlbumImages
    {
        public virtual ICollection<ModelGallery> Images { get; set; }
        public virtual ICollection<AlbumModel> Albums { get; set; }
    }
}
