using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public class ContactManager:IContactService
    {
        IContactDal _contactdal;
        Repository<Contant> repocontact = new Repository<Contant>();

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public Contant GetByID(int id)
        {
            return _contactdal.Find(x => x.ContantID == id);
        }

        public List<Contant> GetList()
        {
            return _contactdal.List();
        }

        public void TAdd(Contant t)
        {
            _contactdal.Insert(t);
        }

        public void TDelete(Contant t)
        {
            throw new NotImplementedException();
        }

        public Contant TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contant t)
        {
            throw new NotImplementedException();
        }
    }
}
