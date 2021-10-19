using BlogWebAPI.Core.Entities.EntityFramework;
using BlogWebAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Entities.Concrete
{
    public class Blog : EntityBase, IBlog
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Detail { get; set; }
        public int? Hit { get; set; }
        public string Photo { get; set; }

        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Subcategory Subcategory { get; set; }

        public void SetHit()
        {
            Hit = 0;
        }
        public Blog()
        {
            SetHit();
        }
    }
}
