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
        public HomeController()
        {
            if (!Images.Any())
            { 
                Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "starWars.jpg" });
                Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "sunset.jpg" });
                Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "surf.jpg" });
                Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "tiger.jpg" });
                Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "Schampoo.jpg" });
            }
        }
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
             

            return View(Images);

        }

        public ActionResult ShowImage(Guid Id)
        {
            var showImage = Images.FirstOrDefault(x => x.Id == Id);
            return View(showImage);

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

        public ActionResult DeleteAImage(Guid Id)
        {
            var image = Images.FirstOrDefault(x => x.Id == Id);
            return View(image);
        }

        [HttpPost]
        public ActionResult DeleteAImage(Guid id, ModelGallery Image)
        {

            var p = Images.FirstOrDefault(x => x.Id == id);
            string fullPath = Request.MapPath("~/Images/" + p.Name);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                Images.Remove(p);
            }
            return RedirectToAction("Gallery");
        }
    }
}