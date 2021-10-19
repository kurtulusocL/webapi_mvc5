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
    public class SubcategoryDAL : EfEntityBaseRepository<Subcategory, ApplicationDbContext>, ISubcategoryDAL
    {
        public async Task Deleted(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var deleted = context.Set<Subcategory>().Where(i => i.Id == id).FirstOrDefault();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Subcategory>> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Subcategory>().Include("Category").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task SetActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Subcategory>().Where(i => i.Id == id).FirstOrDefault();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Subcategory>().Where(i => i.Id == id).FirstOrDefault();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
            }
        }

        public async Task UnDeleted(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var deleted = context.Set<Subcategory>().Where(i => i.Id == id).FirstOrDefault();
                deleted.IsDeleted = false;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
            }
        }
    }
}
