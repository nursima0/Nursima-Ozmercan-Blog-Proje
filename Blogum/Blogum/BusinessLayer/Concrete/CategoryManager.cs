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
   public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void DeleteCategoryBL(int id)
        {
            Category categor = _categoryDal.Find(x => x.CategoryID ==id);
            categor.CategoryStatus = false;
            _categoryDal.Update(categor);
        }

        public void CategoryStatusActiveBL(int id)
        {
            Category ctgry = _categoryDal.Find(x => x.CategoryID == id);
            ctgry.CategoryStatus = true;
            _categoryDal.Update(ctgry);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public Category TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
