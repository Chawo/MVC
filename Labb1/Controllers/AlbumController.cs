using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb1.Models;
using System.IO;

namespace Labb1.Controllers
{
    public class AlbumController : Controller
    {
        static List<AlbumModel> Albums = new List<AlbumModel>();
        // GET: Album
        public ActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAlbum(AlbumModel album)
        {
            album.AlbumID = Guid.NewGuid();
            album.Date = DateTime.Now;
            Albums.Add(album);
            return View();
        }

        public ActionResult ListAlbums()
        {
            return View(Albums);
        }

        public ActionResult AddImageToAlbums()
        {
            var imageToAlbum = new AlbumImages();
            imageToAlbum.Images = HomeController.Images;
            imageToAlbum.Albums = AlbumController.Albums;
            return View(imageToAlbum);
        }

        [HttpPost]
        public ActionResult AddImageToAlbums(IEnumerable<Guid> images, Guid albumID)
        {
            var album = Albums.FirstOrDefault(x => x.AlbumID == albumID);
            foreach (var image in images)
            {
                album.Images.Add(HomeController.Images.FirstOrDefault(x => x.Id == image));
            }
            return Content("OK!");
        }

    }
}