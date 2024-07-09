using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;


namespace Blogum.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        BlogManager bm = new BlogManager(new EFBlogDal());
        AuthorManager aum = new AuthorManager(new EFAuthorDal());

        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryvalues = cm.GetList();
            return PartialView(categoryvalues);
        }

        public ActionResult AdminCategoryList()
        {
            var blogimage = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var blogimage3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            ViewBag.blogimage = blogimage;
            ViewBag.blogimage3 = blogimage3;

            var categorylist = cm.GetList();
            return View(categorylist);
        }

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {

            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results = categoryvalidator.Validate(p);
            if(results.IsValid)
            {
                cm.TAdd(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category ctgr = cm.GetByID(id);
            return View(ctgr);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category C)
        {

            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results = categoryvalidator.Validate(C);
            if (results.IsValid)
            {
                cm.TUpdate(C);
                return RedirectToAction("AdminCategoryList");

            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
           
        }

        public ActionResult DeleteCategory(int id)
        {

            cm.DeleteCategoryBL(id);
            return RedirectToAction("AdminCategoryList");
        }

        public ActionResult CategoryStatusActive(int id)
        {
            cm.CategoryStatusActiveBL(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}