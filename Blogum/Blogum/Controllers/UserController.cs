using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System.Web.Security;
using DataAccessLayer.EntityFramework;

namespace Blogum.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: AuthorLogin

        //Sııf Tanımlamaları
        UserProfileManager up = new UserProfileManager();
        Context c = new Context();
        BlogManager bm = new BlogManager(new EFBlogDal());

        //Index sayfası 
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["AuthorMail"];
            var profilevalue = up.GetAuthorByMail(p);
            return PartialView(profilevalue);
        }


        public ActionResult UpdateUserProfile(Author p)
        {
            up.EditAuthor(p);
            return RedirectToAction("Index");   
        }


        public ActionResult BlogList(string p)
        {

            p = (string)Session["AuthorMail"];
            //yazarın mail adresine göre id deki değerlerini bulup getire komutu
            int id = c.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = up.GetBlogByAuthor(id);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog b = bm.BlogGetByID(id);
            List<SelectListItem> values1 = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            List<SelectListItem> values2 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
            ViewBag.values2 = values2;
            return View(b);

        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.TUpdate(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            List<SelectListItem> values2 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values = values;
            ViewBag.values2 = values2;
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(Blog b)
        {
            bm.TAdd(b);
            return RedirectToAction("BlogList");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin","Login");
        }
    }
}