using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Abstract
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int? id);
        Task Create(Contact entity);
        Task Update(Contact entity);
        Task Delete(Contact entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
