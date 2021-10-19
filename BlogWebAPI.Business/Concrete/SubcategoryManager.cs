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
    public class SubcategoryManager : ISubcategoryService
    {
        ISubcategoryDAL _subcategoryDAL;
        public SubcategoryManager(ISubcategoryDAL subcategoryDAL)
        {
            _subcategoryDAL = subcategoryDAL;
        }
        public async Task Create(Subcategory entity)
        {
            await _subcategoryDAL.Add(entity);
        }

        public async Task Delete(Subcategory entity)
        {
            await _subcategoryDAL.Delete(entity);
        }

        public async Task Deleted(int id)
        {
            await _subcategoryDAL.Deleted(id);
        }

        public async Task<List<Subcategory>> GetAllIncluding()
        {
            return await _subcategoryDAL.GetAllIncluding();
        }

        public async Task<Subcategory> GetById(int? id)
        {
            return await _subcategoryDAL.Get(i => i.Id == id);
        }

        public async Task SetActive(int id)
        {
            await _subcategoryDAL.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _subcategoryDAL.SetDeActive(id);
        }

        public async Task UnDeleted(int id)
        {
            await _subcategoryDAL.UnDeleted(id);
        }

        public async Task Update(Subcategory entity)
        {
            entity.DeletedDate = DateTime.Now.ToLocalTime();
            await _subcategoryDAL.Update(entity);
        }
    }
}
