using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System.Web.Security;

namespace Blogum.Controllers
{
    // global.asax dosyasında bütün sayfalara uyguladığımız authorize bu controllerın viewlerinde muaf olsun komutudur
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        Context c = new Context();

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            var userdata = c.Authors.FirstOrDefault(x => x.AuthorMail == p.AuthorMail && x.Password == p.Password);
            if (userdata != null)
            {
                FormsAuthentication.SetAuthCookie(userdata.AuthorMail, false);
                Session["AuthorMail"] = userdata.AuthorMail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin A)
        {
            var admindata = c.Admins.FirstOrDefault(x => x.UserName == A.UserName && x.Password == A.Password);
            if(admindata != null)
            {
                FormsAuthentication.SetAuthCookie(admindata.UserName, false);
                Session["UserName"] = admindata.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }
    }
}