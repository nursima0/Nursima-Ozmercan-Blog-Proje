using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace Blogum.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cm = new CommentManager(new EFCommentDal());

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentlist = cm.CommentByBlog(id);
            
            return PartialView(commentlist);
        }

        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
                 
        }

        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentStatus = true;
            cm.TAdd(c);
            return PartialView();
        }

        public ActionResult AdminCommentListTrue()
        {
            var commentlist = cm.CommentByStatusTrue();
            return View(commentlist);
        }

        public ActionResult AdminCommentListFalse()
        {
            var comentlist = cm.CommentStatusFalse();
            return View(comentlist);
        }

        public ActionResult CommentStatuesChange(int id)
        {
            cm.UpdateCommentStatus(id);
            return RedirectToAction("AdminCommentListTrue");
        }

        //Yorumu onaylama ve onaylanan yorumun durumu true yapma işlemi
        public ActionResult CommentToApprove(int id)
        {
            cm.UpdateCommentStatusFalse(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}