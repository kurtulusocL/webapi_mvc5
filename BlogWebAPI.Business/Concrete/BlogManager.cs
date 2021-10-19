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
    public class BlogManager : IBlogService
    {
        IBlogDAL _blogDAL;
        public BlogManager(IBlogDAL blogDAL)
        {
            _blogDAL = blogDAL;
        }
        public async Task Create(Blog entity)
        {
            await _blogDAL.Add(entity);
        }

        public async Task Delete(Blog entity)
        {
            await _blogDAL.Delete(entity);
        }

        public async Task Deleted(int id)
        {
            await _blogDAL.Deleted(id);
        }

        public async Task<List<Blog>> GetAllIncluding()
        {
            return await _blogDAL.GetAllIncluding();
        }

        public async Task<List<Blog>> GetBlogByCategory(int? id)
        {
            return await _blogDAL.GetBlogByCategory(id);
        }

        public async Task<List<Blog>> GetBlogBySubcategory(int? id)
        {
            return await _blogDAL.GetBlogBySubcategory(id);
        }

        public async Task<Blog> GetById(int? id)
        {
            return await _blogDAL.Get(i => i.Id == id);
        }

        public async Task<Blog> HitRead(int? id)
        {
            return await _blogDAL.HitRead(id);
        }

        public async Task SetActive(int id)
        {
            await _blogDAL.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _blogDAL.SetDeActive(id);
        }

        public async Task UnDeleted(int id)
        {
            await _blogDAL.UnDeleted(id);
        }

        public async Task Update(Blog entity)
        {
            entity.UpdatedDate = DateTime.Now.ToLocalTime();
            await _blogDAL.Update(entity);
        }
    }
}
