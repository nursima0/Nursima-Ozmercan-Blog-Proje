using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using BusinessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class SubScribeMailManager:IMailService
    {
        IMailDal _maildal;

        public SubScribeMailManager(IMailDal maildal)
        {
            _maildal = maildal;
        }


        public SubScribeMail GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubScribeMail> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(SubScribeMail t)
        {
            _maildal.Insert(t);
        }

        public void TDelete(SubScribeMail t)
        {
            throw new NotImplementedException();
        }

        public SubScribeMail TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SubScribeMail t)
        {
            throw new NotImplementedException();
        }
    }
}
