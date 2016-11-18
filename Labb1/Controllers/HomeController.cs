using Labb1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labb1.Controllers
{
    public class HomeController : Controller
    {
        static List<ModelGallery> Images = new List<ModelGallery>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            var photos = new ModelGallery()
            {
                Image = Directory.EnumerateFiles(Server.MapPath("~/Images/")).Select(fn => "~/Images/" + Path.GetFileName(fn))
            };
             

            return View(photos);

        }


        public ActionResult Upload()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Upload(ModelGallery Image, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid) { return View(Image); }
            if (file == null)
            {
                ModelState.AddModelError("error", "Ingen bild?");
                return View(Image);
            }
            file.SaveAs(Path.Combine(Server.MapPath("~/Images"), file.FileName));
            return View();
        }
    }
}