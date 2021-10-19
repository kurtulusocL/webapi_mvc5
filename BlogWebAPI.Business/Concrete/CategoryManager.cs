using BlogWebAPI.Business.Abstract;
using BlogWebAPI.DataAccess.Abstract;
using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        //[ValidationAspect(typeof(CategoryValidation), Priority = 1)]
        public async Task Create(Category entity)
        {
            await _categoryDAL.Add(entity);
        }

        public async Task Delete(Category entity)
        {
            await _categoryDAL.Delete(entity);
        }

        public async Task Deleted(int id)
        {
            await _categoryDAL.Deleted(id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryDAL.GetAll();
        }

        public async Task<Category> GetById(int? id)
        {
            return await _categoryDAL.Get(i => i.Id == id);
        }

        public async Task SetActive(int id)
        {
            await _categoryDAL.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _categoryDAL.SetDeActive(id);
        }

        public async Task UnDeleted(int id)
        {
            await _categoryDAL.UnDeleted(id);
        }

        public async Task Update(Category entity)
        {
            entity.UpdatedDate = DateTime.Now.ToLocalTime();
            await _categoryDAL.Update(entity);
        }
    }
}
