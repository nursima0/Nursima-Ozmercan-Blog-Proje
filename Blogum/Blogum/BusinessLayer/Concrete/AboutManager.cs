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
    public class AboutManager:IAboutService

    {
        IAboutDal _aboutdal;
        Repository<About> repoabout = new Repository<About>();

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }


        public List<About> GetList()
        {
            return _aboutdal.List();
        }


        public void TAdd(About t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(About t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            _aboutdal.Update(t);
        }

        public About GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public About TGetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
