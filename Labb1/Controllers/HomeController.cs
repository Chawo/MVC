//using Labb1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MyDataForLabb1;
using MyDataForLabb1.Models;
using MyDataForLabb1.Repositories;

namespace Labb1.Controllers
{
    public class HomeController : Controller
    {
        private ImageRepositories imageRepo = new ImageRepositories();
        private CommentRepositories commentRepo = new CommentRepositories();

        public ActionResult Gallery()
        {
            return View(imageRepo.GetAllImages());

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
                ModelState.AddModelError("Error", "Det finns ingen bild att ladda upp?");
                return View(Image);
            }
            file.SaveAs(Path.Combine(Server.MapPath("~/Images"), file.FileName));

            Image.Name = file.FileName;
            imageRepo.Add(Image);

            return View();
        }

        public ActionResult DeleteAImage(Guid Id)
        {
            var p = imageRepo.GetAllImages().FirstOrDefault(x => x.Id == Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult DeleteAImage(Guid id, ModelGallery Image)
        {
            var p = imageRepo.GetAllImages().FirstOrDefault(x => x.Id == id);
            string fullPath = Request.MapPath("~/Images/" + p.Name);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                imageRepo.Delete(id);
            }
            return RedirectToAction("Gallery");
        }

        public ActionResult ShowImage(Guid Id)
        {
            var showImage = imageRepo.GetAllImagesComment().FirstOrDefault(x => x.Id == Id);
             return View(showImage);

        }

        [HttpPost]
        public ActionResult ShowImage(Guid Id, string ImageComment)
        {
            var showImage = imageRepo.GetAllImagesComment().FirstOrDefault(x => x.Id == Id);
            commentRepo.AddComment(showImage.Id, ImageComment);
            return View(showImage);

        }

        //            p.ImageComments.Add(new Comments { CommentsImages = ImageComment });

        ////*************** Här börjar den gamla koden utan databas
        ////*************** Här börjar den gamla koden utan databas
        ////*************** Här börjar den gamla koden utan databas
        ////*************** Här börjar den gamla koden utan databas
        ////*************** Här börjar den gamla koden utan databas
        ////*************** Här börjar den gamla koden utan databas
        ////*************** Här börjar den gamla koden utan databas

        //public static ICollection<ModelGallery> Images = new List<ModelGallery>();
        //public HomeController()
        //{
        //    if (!Images.Any())
        //    {
        //        Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "starWars.jpg", ImageComments = new List<Comments> { new Comments { CommentsImages = "Star Wars Comments" } } });
        //        Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "sunset.jpg", ImageComments = new List<Comments> { new Comments { CommentsImages = "Sunset Comments" } } });
        //        Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "surf.jpg", ImageComments = new List<Comments> { new Comments { CommentsImages = "Surf Comments" } } });
        //        Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "tiger.jpg", ImageComments = new List<Comments> { new Comments { CommentsImages = "Tiger Comments" } } });
        //        Images.Add(new ModelGallery { Id = Guid.NewGuid(), Name = "Schampoo.jpg", ImageComments = new List<Comments> { new Comments { CommentsImages = "Schampoo Comments" } } });
        //    }
        //}
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult Gallery()
        //{  
        //    return View(Images);

        //}

        //public ActionResult ShowImage(Guid Id)
        //{
        //    var showImage = Images.FirstOrDefault(x => x.Id == Id);
        //    return View(showImage);

        //}

        //[HttpPost]
        //public ActionResult ShowImage(Guid Id, string ImageComment)
        //{
        //    var p = Images.FirstOrDefault(x => x.Id == Id);
        //    p.ImageComments.Add(new Comments { CommentsImages = ImageComment });
        //    return View(p);

        //}


        //public ActionResult Upload()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Upload(ModelGallery Image, HttpPostedFileBase file)
        //{
        //    if (!ModelState.IsValid) { return View(Image); }
        //    if (file == null)
        //    {
        //        ModelState.AddModelError("Error", "Det finns ingen bild att ladda upp?");
        //        return View(Image);
        //    }
        //    file.SaveAs(Path.Combine(Server.MapPath("~/Images"), file.FileName));
        //    return View();
        //}

        //public ActionResult DeleteAImage(Guid Id)
        //{
        //    var image = Images.FirstOrDefault(x => x.Id == Id);
        //    return View(image);
        //}

        //[HttpPost]
        //public ActionResult DeleteAImage(Guid id, ModelGallery Image)
        //{

        //    var p = Images.FirstOrDefault(x => x.Id == id);
        //    string fullPath = Request.MapPath("~/Images/" + p.Name);

        //    if (System.IO.File.Exists(fullPath))
        //    {
        //        System.IO.File.Delete(fullPath);
        //        Images.Remove(p);
        //    }
        //    return RedirectToAction("Gallery");
        //}


    }
}