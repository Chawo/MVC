using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataForLabb1.Models;

namespace MyDataForLabb1.Repositories
{
    public class CommentRepositories
    {
        public IEnumerable<ModelGallery> GetAllImagesComment()
        {
            using (var ctx = new Labb1Context())
            {
                 return ctx.image.Include("ImageComments").ToList();
            }
        }

        public void AddComment(ModelGallery image, string ImageComment)
        {
            using (var ctx = new Labb1Context())
            {
                var CommentImage = ctx.image.First(a => a.Id == image.Id);

                if (CommentImage != null)
                {
                    var MYCOMMENT = new Comments()
                    {
                        CommentsImages = ImageComment,
                        ModelGallery_Id = CommentImage
                    }; 

                    ctx.comment.Add(MYCOMMENT);
                    ctx.SaveChanges();
                }

                
            }
        }
    }
}
