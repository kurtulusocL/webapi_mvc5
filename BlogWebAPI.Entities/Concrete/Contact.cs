using BlogWebAPI.Core.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Entities.Concrete
{
    public class Contact : EntityBase
    {
        public string EmailAddress { get; set; }
        public string SecondEmailAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
