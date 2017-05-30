using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dbContext = new ForumDbContext();

            var categories = dbContext.Categories.ToList();
            this.ViewBag.Categories = categories;

            return this.View(categories);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}