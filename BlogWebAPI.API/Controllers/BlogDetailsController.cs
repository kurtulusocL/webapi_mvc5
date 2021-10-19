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
    public class BlogDetailsController : ApiController
    {
        private readonly IBlogDetailService _blogDetailService;
        public BlogDetailsController(IBlogDetailService blogDetailService)
        {
            _blogDetailService = blogDetailService;
        }
        public BlogDetailsController()
        {

        }

        [ResponseType(typeof(IEnumerable<BlogDetail>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllBlogDetails()
        {
            var result = await _blogDetailService.GetAllIncluding();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(BlogDetail))]
        [HttpGet]
        public async Task<IHttpActionResult> GetBlogDetail(int? id)
        {
            var result = await _blogDetailService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(BlogDetail))]
        [HttpPost]
        public async Task<IHttpActionResult> EditBlogDetail(int? id, BlogDetail model)
        {
            var updateDetail = await _blogDetailService.GetById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else if (updateDetail != null)
            {
                return BadRequest();
            }
            else
            {
                await _blogDetailService.Update(model);
                return Ok();
            }
        }

        [ResponseType(typeof(BlogDetail))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBlogDetail(int id)
        {
            var deleteDetail = await _blogDetailService.GetById(id);
            if (deleteDetail == null)
            {
                return NotFound();
            }
            else
            {
                await _blogDetailService.Delete(deleteDetail);
            }
            return Ok(deleteDetail);
        }

        [ResponseType(typeof(BlogDetail))]
        public async Task<IHttpActionResult> SetActiveCategory(int id)
        {
            var blogDetail = await _blogDetailService.GetById(id);
            if (blogDetail != null)
            {
                await _blogDetailService.SetActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(BlogDetail))]
        public async Task<IHttpActionResult> SetDeActiveCategory(int id)
        {
            var blogDetail = await _blogDetailService.GetById(id);
            if (blogDetail != null)
            {
                await _blogDetailService.SetDeActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(BlogDetail))]
        public async Task<IHttpActionResult> DeletedCategory(int id)
        {
            var blogDetail = await _blogDetailService.GetById(id);
            if (blogDetail != null)
            {
                await _blogDetailService.Deleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(BlogDetail))]
        public async Task<IHttpActionResult> NotDeletedCategory(int id)
        {
            var blogDetail = await _blogDetailService.GetById(id);
            if (blogDetail != null)
            {
                await _blogDetailService.UnDeleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
