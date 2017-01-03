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
        public IEnumerable<ModelGallery> GetAllCommentForImages()
        {

            using (var ctx = new Labb1Context())
            {
                return ctx.image.ToList();
            }

        }

        public void AddComment(Guid Id, string ImageComment)
        {
            using (var ctx = new Labb1Context())
            {
                var newCommentForImage = new Comments
                {
                    Id = Guid.NewGuid(),
                     CommentsImages = ImageComment

                };

                ctx.comment.Add(newCommentForImage);

                ctx.SaveChanges();
            }
        }
    }
}
