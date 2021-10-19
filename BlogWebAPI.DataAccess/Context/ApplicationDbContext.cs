using BlogWebAPI.Entities.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogDetail> BlogDetail { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
    }
}
