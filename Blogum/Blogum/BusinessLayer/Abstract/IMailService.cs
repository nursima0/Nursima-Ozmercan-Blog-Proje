using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Abstract
{
    public interface IMailService : IGenericService<SubScribeMail>
    {
    }
}
