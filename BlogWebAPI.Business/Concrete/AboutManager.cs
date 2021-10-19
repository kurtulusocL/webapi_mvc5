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
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;
        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }
        public async Task Create(About entity)
        {
            await _aboutDAL.Add(entity);
        }

        public async Task Delete(About entity)
        {
            await _aboutDAL.Delete(entity);
        }

        public async Task Deleted(int id)
        {
            await _aboutDAL.Deleted(id);
        }

        public async Task<List<About>> GetAll()
        {
            return await _aboutDAL.GetAll();
        }

        public async Task<About> GetById(int? id)
        {
            return await _aboutDAL.Get(i => i.Id == id);
        }

        public async Task SetActive(int id)
        {
            await _aboutDAL.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _aboutDAL.SetDeActive(id);
        }

        public async Task UnDeleted(int id)
        {
            await _aboutDAL.UnDeleted(id);
        }

        public async Task Update(About entity)
        {
            entity.UpdatedDate = DateTime.Now.ToLocalTime();
            await _aboutDAL.Update(entity);
        }
    }
}
