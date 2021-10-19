using BlogWebAPI.Business.Abstract;
using BlogWebAPI.DataAccess.Abstract;
using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Business.Concrete
{
    public class ReportManager : IReportService
    {
        IReportDAL _reportDAL;
        public ReportManager(IReportDAL reportDAL)
        {
            _reportDAL = reportDAL;
        }
        public async Task Create(Report entity)
        {
            await _reportDAL.Add(entity);
        }

        public async Task Delete(Report entity)
        {
            await _reportDAL.Delete(entity);
        }

        public async Task Deleted(int id)
        {
            await _reportDAL.Deleted(id);
        }

        public async Task<List<Report>> GetAllIncluding()
        {
            return await _reportDAL.GetAllIncluding();
        }

        public async Task<List<Report>> GetBlogByReport(int? id)
        {
            return await _reportDAL.GetBlogByReport(id);
        }

        public async Task<Report> GetById(int? id)
        {
            return await _reportDAL.Get(i => i.Id == id);
        }

        public async Task SetActive(int id)
        {
            await _reportDAL.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _reportDAL.SetDeActive(id);
        }

        public async Task UnDeleted(int id)
        {
            await _reportDAL.UnDeleted(id);
        }

        public async Task Update(Report entity)
        {
            entity.UpdatedDate = DateTime.Now.ToLocalTime();
            await _reportDAL.Update(entity);
        }
    }
}
