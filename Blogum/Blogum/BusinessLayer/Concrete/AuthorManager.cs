using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
   public class AuthorManager:IAuthorService
    {
        IAuthorDal _authordal; 

        Repository<Author> repoabout = new Repository<Author>();

        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }
        //Yeni yazar eklem işlemi
        public void AddAuthorBL(Author p)
        {
            _authordal.Insert(p);
        }
        public List<Author> GetList()
        {
           return _authordal.List();
        }


        public Author GetByID(int id)
        {
            return _authordal.GetByID(id);
        }

        public void AuthorDelete(Author author)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Author t)
        {
            _authordal.Insert(t);
        }

        public void TDelete(Author t)
        {
            _authordal.Delete(t);
        }

        public void TUpdate(Author t)
        {
            _authordal.Update(t);
        }

        public Author TGetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
