using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.EntityFramework;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace Blogum.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        AuthorManager authormanager = new AuthorManager(new EFAuthorDal());
        BlogManager blogmanager = new BlogManager(new EFBlogDal());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogmanager.BlgGetByID(id);
            return PartialView(authordetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
          
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
            var authorlist = authormanager.GetList();
            return View(authorlist);
        }

        //bu alanda httpget sayfa yüklenirken yapılacak işlemleri kontrol ediyor view bu alandan türetilir
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        //bu alanda httppost ile herhangi bir butona tıklandıktan sonra yapılacak işlemler kontrol ediliyor 
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            AuthorValidator authorvalidator = new AuthorValidator();
            ValidationResult results = authorvalidator.Validate(p);
            if(results.IsValid)
            {
                authormanager.TAdd(p);
                return RedirectToAction("AuthorList");
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
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.GetByID(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            AuthorValidator authorvalidator = new AuthorValidator();
            ValidationResult results = authorvalidator.Validate(p);
            if(results.IsValid)
            {
                authormanager.TUpdate(p);
                return RedirectToAction("AuthorList");
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

        public ActionResult AuthorDelete(int id)
        {
            Author author = authormanager.GetByID(id);
            authormanager.TDelete(author);
            return RedirectToAction("AuthorList");
        }
    }
}