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

        AlbumRepositories Albumrepo = new AlbumRepositories();
        

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

        //public ActionResult AddImageToAlbums()
        //{
        //    var imageToAlbum = new AlbumImages();
        //    imageToAlbum.Images = HomeController.Images;
        //    imageToAlbum.Albums = AlbumController.Albums;
        //    return View(imageToAlbum);
        //}

        //[HttpPost]
        //public ActionResult AddImageToAlbums(IEnumerable<Guid> images, Guid albumID)
        //{

        //    var album = Albums.FirstOrDefault(x => x.AlbumID == albumID);
        //    foreach (var image in images)
        //    {

        //        album.AlbumListOfImages.Add(HomeController.Images.FirstOrDefault(x => x.Id == image));
        //    }
        //    return Content("OK!");
        //}

        //public ActionResult ImagesInAlbums(Guid AlbumID)
        //{
        //    var a = Albums.First(x => x.AlbumID == AlbumID);
        //    return View(a);
        //}

        //[HttpPost]
        //public ActionResult ImagesInAlbums(Guid AlbumID, string AlbumComment)
        //{
        //    var commentForAlbum = Albums.First(x => x.AlbumID == AlbumID);
        //    commentForAlbum.Comments.Add(new Comments { CommentsAlbums = AlbumComment });
        //    return View(commentForAlbum);
        //}


    }
}