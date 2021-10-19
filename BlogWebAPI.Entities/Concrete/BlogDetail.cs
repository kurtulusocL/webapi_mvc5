using BlogWebAPI.Core.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Entities.Concrete
{
    public class BlogDetail : EntityBase
    {
        public string Subdetail { get; set; }
        public string Text { get; set; }

        public int? BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
