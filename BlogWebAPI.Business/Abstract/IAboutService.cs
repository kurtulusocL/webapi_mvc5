using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Abstract
{
    public interface IAboutService
    {
        Task<List<About>> GetAll();
        Task<About> GetById(int? id);
        Task Create(About entity);
        Task Update(About entity);
        Task Delete(About entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
