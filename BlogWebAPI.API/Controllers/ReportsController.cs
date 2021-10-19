using BlogWebAPI.Business.Abstract;
using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace BlogWebAPI.API.Controllers
{
    public class ReportsController : ApiController
    {
        private readonly IReportService _reportService;
        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public ReportsController()
        {

        }

        [ResponseType(typeof(IEnumerable<Report>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllReports()
        {
            var result = await _reportService.GetAllIncluding();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(IEnumerable<Report>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetBlogsByReport(int? id)
        {
            var blogByReport = await _reportService.GetBlogByReport(id);
            if (blogByReport != null)
            {
                return Ok(blogByReport);
            }
            return BadRequest();
        }

        [ResponseType(typeof(Report))]
        [HttpGet]
        public async Task<IHttpActionResult> GetReport(int? id)
        {
            var result = await _reportService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(Report))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteReport(int id)
        {
            var deleteReport = await _reportService.GetById(id);
            if (deleteReport == null)
            {
                return NotFound();
            }
            else
            {
                await _reportService.Delete(deleteReport);
            }
            return Ok(deleteReport);
        }

        [ResponseType(typeof(Report))]
        public async Task<IHttpActionResult> SetActiveReport(int id)
        {
            var report = await _reportService.GetById(id);
            if (report != null)
            {
                await _reportService.SetActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Report))]
        public async Task<IHttpActionResult> SetDeActiveReport(int id)
        {
            var report = await _reportService.GetById(id);
            if (report != null)
            {
                await _reportService.SetDeActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Report))]
        public async Task<IHttpActionResult> DeletedReport(int id)
        {
            var report = await _reportService.GetById(id);
            if (report != null)
            {
                await _reportService.Deleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Report))]
        public async Task<IHttpActionResult> NotDeletedReport(int id)
        {
            var report = await _reportService.GetById(id);
            if (report != null)
            {
                await _reportService.UnDeleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
