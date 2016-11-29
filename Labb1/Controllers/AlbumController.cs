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
        // GET: Album
        public ActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAlbum(AlbumModel album, HttpPostedFileBase file)
        {
            album.Date = DateTime.Now;
            file.SaveAs(Path.Combine(Server.MapPath("~/Album"), file.FileName));
            return View();
        }
    }
}