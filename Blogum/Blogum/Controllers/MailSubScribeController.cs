using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace Blogum.Controllers
{
    [AllowAnonymous]
    public class MailSubScribeController : Controller
    {
        // GET: MailSubScribe
        SubScribeMailManager sm = new SubScribeMailManager(new EFMailDal());
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(SubScribeMail p )
        {
            
            sm.TAdd(p);
            return PartialView();
        }
    }
}