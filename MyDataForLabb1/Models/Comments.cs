using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDataForLabb1.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentsImages { get; set; }
        public string CommentsAlbums { get; set; }
        public virtual ModelGallery ModelGallery_Id { get; set; }

    }
}
