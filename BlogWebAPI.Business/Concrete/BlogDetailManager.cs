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
    public class BlogDetailManager : IBlogDetailService
    {
        IBlogDetailDAL _blogDetailDAL;
        public BlogDetailManager(IBlogDetailDAL blogDetailDAL)
        {
            _blogDetailDAL = blogDetailDAL;
        }
        public async Task Create(BlogDetail entity)
        {
            await _blogDetailDAL.Add(entity);
        }

        public async Task Delete(BlogDetail entity)
        {
            await _blogDetailDAL.Delete(entity);
        }

        public async Task Deleted(int id)
        {
            await _blogDetailDAL.Deleted(id);
        }

        public async Task<List<BlogDetail>> GetAllIncluding()
        {
            return await _blogDetailDAL.GetAllIncluding();
        }

        public async Task<BlogDetail> GetById(int? id)
        {
            return await _blogDetailDAL.Get(i => i.Id == id);
        }

        public async Task SetActive(int id)
        {
            await _blogDetailDAL.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _blogDetailDAL.SetDeActive(id);
        }

        public async Task UnDeleted(int id)
        {
            await _blogDetailDAL.UnDeleted(id);
        }

        public async Task Update(BlogDetail entity)
        {
            entity.UpdatedDate = DateTime.Now.ToLocalTime();
            await _blogDetailDAL.Update(entity);
        }
    }
}
