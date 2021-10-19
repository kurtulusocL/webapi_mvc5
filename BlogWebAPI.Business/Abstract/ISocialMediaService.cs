using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Abstract
{
    public interface ISocialMediaService
    {
        Task<List<SocialMedia>> GetAll();
        Task<SocialMedia> GetById(int? id);
        Task Create(SocialMedia entity);
        Task Update(SocialMedia entity);
        Task Delete(SocialMedia entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
