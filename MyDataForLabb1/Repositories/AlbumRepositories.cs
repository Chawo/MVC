using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataForLabb1.Models;

namespace MyDataForLabb1.Repositories
{
    
    public class AlbumRepositories 
    {

        public IEnumerable<AlbumModel> GetAllAlbums()
        {

            using (var ctx = new Labb1Context())
            { 
                return ctx.album.Include("AlbumListOfImages").ToList();
            }

        }

        public void AddImageToAlbum(Guid imageID, Guid albumID)
        {

            using (var ctx = new Labb1Context())
            {
                var AddImagesToAlbum = new AlbumImages()
                {
                    AlbumID = albumID,
                    Id = imageID
                };
                ctx.albumImage.Add(AddImagesToAlbum);
                ctx.SaveChanges();

            }

        }

        public void AddCommentToAlbum(Guid id, string albumComment)
        {
            using (var ctx = new Labb1Context())
            {
                var addCommentToAlbum = new Comments()
                {
                    CommentsAlbums = albumComment
                };
                ctx.comment.Add(addCommentToAlbum);
                ctx.SaveChanges();
            }
        }

        //public void ShowImagesInAlbum(Guid AlbumID)
        //{
        //    using (var ctx = new Labb1Context())
        //    {
        //        var album = GetAllAlbums().First(x => x.AlbumID == AlbumID);
        //        foreach (var item in album.AlbumListOfImages)
        //        {

        //        }

        //    }
        //}
    }
}
