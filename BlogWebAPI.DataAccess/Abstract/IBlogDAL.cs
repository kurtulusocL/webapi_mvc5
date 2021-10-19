using BlogWebAPI.Core.DataAccess;
using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.DataAccess.Abstract
{
    public interface IBlogDAL : IEntityRepository<Blog>
    {
        Task<List<Blog>> GetAllIncluding();
        Task<List<Blog>> GetBlogByCategory(int? id);
        Task<List<Blog>> GetBlogBySubcategory(int? id);
        Task<Blog> HitRead(int? id);
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
