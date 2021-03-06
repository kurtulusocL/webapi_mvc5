using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Abstract
{
    public interface IReportService
    {
        Task<List<Report>> GetAllIncluding();
        Task<List<Report>> GetBlogByReport(int? id);
        Task<Report> GetById(int? id);
        Task Create(Report entity);
        Task Update(Report entity);
        Task Delete(Report entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
        Task Deleted(int id);
        Task UnDeleted(int id);
    }
}
