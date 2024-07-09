using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
   public interface IRepository <T>
    {
        List<T> List();

        void Insert(T p);

        void Update(T p);

        void Delete(T p);

        T GetByID(int id);
        List<T> List(Expression<Func<T, bool>> Filter);

        T Find(Expression<Func<T, bool>> where);
    }
}
