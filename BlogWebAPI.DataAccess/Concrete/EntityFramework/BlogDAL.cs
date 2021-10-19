using BlogWebAPI.Core.DataAccess.EntityFramework;
using BlogWebAPI.DataAccess.Abstract;
using BlogWebAPI.DataAccess.Context;
using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.DataAccess.Concrete.EntityFramework
{
    public class BlogDAL : EfEntityBaseRepository<Blog, ApplicationDbContext>, IBlogDAL
    {
        public async Task Deleted(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var deleted = context.Set<Blog>().Where(i => i.Id == id).FirstOrDefault();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Blog>> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Blog>().Include("Category").Include("Subcategory").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<List<Blog>> GetBlogByCategory(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Blog>().Include("BlogDetails").Include("Reports").Include("Category").Include("Subcategory").Where(i => i.CategoryId == id && i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<List<Blog>> GetBlogBySubcategory(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Blog>().Include("BlogDetails").Include("Reports").Include("Category").Include("Subcategory").Where(i => i.SubcategoryId == id && i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<Blog> HitRead(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var hit = context.Set<Blog>().Where(i => i.Id == id).SingleOrDefault();
                hit.Hit++;
                await context.SaveChangesAsync();
                return hit;
            }
        }

        public async Task SetActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Blog>().Where(i => i.Id == id).FirstOrDefault();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Blog>().Where(i => i.Id == id).FirstOrDefault();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
            }
        }

        public async Task UnDeleted(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var deleted = context.Set<Blog>().Where(i => i.Id == id).FirstOrDefault();
                deleted.IsDeleted = false;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
            }
        }
    }
}
