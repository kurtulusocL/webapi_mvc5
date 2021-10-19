﻿using BlogWebAPI.Core.DataAccess;
using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.DataAccess.Abstract
{
    public interface ISubcategoryDAL : IEntityRepository<Subcategory>
    {
        Task<List<Subcategory>> GetAllIncluding();
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
