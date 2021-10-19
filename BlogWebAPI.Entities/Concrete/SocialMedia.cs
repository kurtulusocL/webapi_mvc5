using BlogWebAPI.Core.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Entities.Concrete
{
    public class SocialMedia : EntityBase
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }
    }
}
