using BlogWebAPI.Core.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Entities.Concrete
{
    public class Report : EntityBase
    {
        public string NameSurname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }

        public int? BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
