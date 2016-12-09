using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using MyDataForLabb1;
using MyDataForLabb1.Models;
using MyDataForLabb1.Repositories;
//using Labb1.Models;


namespace Labb1.Controllers
{
    public class AlbumController : Controller
    {
        //public static List<AlbumModel> Albums = new List<AlbumModel>();

        private AlbumRepositories Albumrepo = new AlbumRepositories();
        private ImageRepositories imageRepo = new ImageRepositories();


        public ActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult CreateAlbum(AlbumModel album)
        {
            //album.AlbumID = Guid.NewGuid();
            //album.Date = DateTime.Now;
            //Albums.Add(album);
            //return Redirect("ListAlbums");

            using (var ctx = new Labb1Context())
            {
                album.AlbumID = Guid.NewGuid();
                ctx.album.Add(album);
                ctx.SaveChanges();
            }

            return View();

        }

        public ActionResult ListAlbums()
        {
            return View(Albumrepo.GetAllAlbums());
            //return View(Albums);
        }

        public ActionResult AddImageToAlbums()
        {
            using (var ctx = new Labb1Context())
            {
                var ListOfImages = ctx.image.ToList();
                var ListOfAlbum = ctx.album.ToList();

                var imageToAlbum = new AlbumImages();
                imageToAlbum.Images = ListOfImages;
                imageToAlbum.Albums = ListOfAlbum;
                return View(imageToAlbum);
            }
            //var imageToAlbum = new AlbumImages();
            //imageToAlbum.Images = HomeController.Images;
            //imageToAlbum.Albums = AlbumController.Albums;
            //return View(imageToAlbum);
        }

        [HttpPost]
        public ActionResult AddImageToAlbums(IEnumerable<Guid> images, Guid albumID)
        {
            foreach (var imageID in images)
            {
                Albumrepo.AddImageToAlbum(imageID, albumID);
            }
            //var album = Albums.FirstOrDefault(x => x.AlbumID == albumID);
            //foreach (var image in images)
            //{

            //    album.AlbumListOfImages.Add(HomeController.Images.FirstOrDefault(x => x.Id == image));
            //}
            return Content("OK!");
        }

        public ActionResult ImagesInAlbums(Guid AlbumID)
        {
            using (var ctx = new Labb1Context())
            {
                var album = Albumrepo.GetAllAlbums().First(x => x.AlbumID == AlbumID);
                
                return View(album);

            }
            //var a = Albums.First(x => x.AlbumID == AlbumID);
        }

        [HttpPost]
        public ActionResult ImagesInAlbums(Guid AlbumID, string AlbumComment)
        {
            Albumrepo.AddCommentToAlbum(AlbumID, AlbumComment);
            return View();
            //var commentForAlbum = Albums.First(x => x.AlbumID == AlbumID);
            //commentForAlbum.Comments.Add(new Comments { CommentsAlbums = AlbumComment });
            //return View(commentForAlbum);
        }


    }
}