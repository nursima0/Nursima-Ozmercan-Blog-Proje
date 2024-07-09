using Blogum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;


namespace Blogum.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizeResult()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryModels> CategoryList()
        {
            List<CategoryModels> c = new List<CategoryModels>();
            c.Add(new CategoryModels() { CategoryName = "Film & Dizi", BlogCount = 14 });
            c.Add(new CategoryModels() { CategoryName = "Kitap", BlogCount = 10 });
            c.Add(new CategoryModels() { CategoryName = "Şiir", BlogCount = 12 });
            c.Add(new CategoryModels() { CategoryName = "İncelemeler", BlogCount = 11 });
            c.Add(new CategoryModels() { CategoryName = "Yazarın Kaleminden", BlogCount = 9 });
            return c;
        }


        public ActionResult VisualizeResult2()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<RatingModel> BlogList()
        {
            List<RatingModel> c2 = new List<RatingModel>();
            using(var c=new Context())
            {
                c2 = c.Blogs.Select(x => new RatingModel { BlogName = x.BlogTitle, Rating = x.BlogRating }).ToList();
            }
            return c2;
        }
        public ActionResult Chart1()
        {
            return View();
        }
        public ActionResult Chart2()
        {
            return View();
        }

        public ActionResult Chart3()
        {
            return View();
        }

    }
}