using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Abstract
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllIncluding();
        Task<Blog> GetById(int? id);
        Task<List<Blog>> GetBlogByCategory(int? id);
        Task<List<Blog>> GetBlogBySubcategory(int? id);
        Task<Blog> HitRead(int? id);
        Task Create(Blog entity);
        Task Update(Blog entity);
        Task Delete(Blog entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
