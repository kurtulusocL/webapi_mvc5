using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Abstract
{
    public interface ISubcategoryService
    {
        Task<List<Subcategory>> GetAllIncluding();
        Task<Subcategory> GetById(int? id);
        Task Create(Subcategory entity);
        Task Update(Subcategory entity);
        Task Delete(Subcategory entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
