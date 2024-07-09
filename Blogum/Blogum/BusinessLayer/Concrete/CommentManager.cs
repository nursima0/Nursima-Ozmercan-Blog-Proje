using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class CommentManager:ICommentService
    {
        ICommentDal _commentdal;
        Repository<Comment> repocomment = new Repository<Comment>();

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public List<Comment> CommentList()
        {
            return repocomment.List();
        }
        public List<Comment> CommentByBlog(int id)
        {
            return _commentdal.List(x => x.BlogID == id);
        }

        public List<Comment> CommentByStatusTrue()
        {
            return _commentdal.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentStatusFalse()
        {
            return repocomment.List(x => x.CommentStatus == false);
        }

        public void UpdateCommentStatus(int id)
        {
            Comment comment = _commentdal.Find(x => x.CommentID == id);
            comment.CommentStatus = false;
            _commentdal.Update(comment);
        }

        public void UpdateCommentStatusFalse(int id)
        {
            Comment commnt = _commentdal.Find(x => x.CommentID == id);
            commnt.CommentStatus = true;
            _commentdal.Update(commnt);
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public Comment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void CommentDelete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void CommentUpdate(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Comment t)
        {
            _commentdal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
