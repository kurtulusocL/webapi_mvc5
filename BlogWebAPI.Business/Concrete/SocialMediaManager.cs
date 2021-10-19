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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDAL _socialMediaDAL;
        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }
        public async Task Create(SocialMedia entity)
        {
            await _socialMediaDAL.Add(entity);
        }

        public async Task Delete(SocialMedia entity)
        {
            await _socialMediaDAL.Delete(entity);
        }

        public async Task Deleted(int id)
        {
            await _socialMediaDAL.Deleted(id);
        }

        public async Task<List<SocialMedia>> GetAll()
        {
            return await _socialMediaDAL.GetAll();
        }

        public async Task<SocialMedia> GetById(int? id)
        {
            return await _socialMediaDAL.Get(i => i.Id == id);
        }

        public async Task SetActive(int id)
        {
            await _socialMediaDAL.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _socialMediaDAL.SetDeActive(id);
        }

        public async Task UnDeleted(int id)
        {
            await _socialMediaDAL.UnDeleted(id);
        }

        public async Task Update(SocialMedia entity)
        {
            entity.UpdatedDate = DateTime.Now.ToLocalTime();
            await _socialMediaDAL.Update(entity);
        }
    }
}
