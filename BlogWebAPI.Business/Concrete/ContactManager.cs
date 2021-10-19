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
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;
        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }
        public async Task Create(Contact entity)
        {
            await _contactDAL.Add(entity);
        }

        public async Task Delete(Contact entity)
        {
            await _contactDAL.Delete(entity);
        }

        public async Task Deleted(int id)
        {
            await _contactDAL.Deleted(id);
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _contactDAL.GetAll();
        }

        public async Task<Contact> GetById(int? id)
        {
            return await _contactDAL.Get(i => i.Id == id);
        }

        public async Task SetActive(int id)
        {
            await _contactDAL.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _contactDAL.SetDeActive(id);
        }

        public async Task UnDeleted(int id)
        {
            await _contactDAL.UnDeleted(id);
        }

        public async Task Update(Contact entity)
        {
            entity.UpdatedDate = DateTime.Now.ToLocalTime();
            await _contactDAL.Update(entity);
        }
    }
}
