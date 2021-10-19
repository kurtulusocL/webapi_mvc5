using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Abstract
{
    public interface IBlogDetailService
    {
        Task<List<BlogDetail>> GetAllIncluding();
        Task<BlogDetail> GetById(int? id);
        Task Create(BlogDetail entity);
        Task Update(BlogDetail entity);
        Task Delete(BlogDetail entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
