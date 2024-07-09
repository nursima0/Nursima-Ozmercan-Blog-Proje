using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;
using BusinessLayer.ValidationRules;
using BusinessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }

        public List<Blog> BlgGetByID(int id)
        {
            return  _blogdal.List(x => x.BlogID == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogdal.List(x => x.AuthorID == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return _blogdal.List(x => x.CategoryID == id);
        }

        public List<Blog> GetList()
        {
            return _blogdal.List();
        }
        public Blog BlogGetByID(int id)
        {
            return _blogdal.GetByID(id);
        }

        public Blog GetByID(int id)
        {
            return _blogdal.GetByID(id);
        }

        public void TAdd(Blog t)
        {
            _blogdal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogdal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogdal.Update(t);
        }

        public Blog TGetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
