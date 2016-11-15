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
    }
}