using BlogWebAPI.Business.Abstract;
using BlogWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace BlogWebAPI.API.Controllers
{
    public class BlogsController : ApiController
    {
        private readonly IBlogService _blogService;
        private readonly IReportService _reportService;
        private readonly IBlogDetailService _blogDetailService;
        public BlogsController(IBlogService blogService, IReportService reportService, IBlogDetailService blogDetailService)
        {
            _blogService = blogService;
            _reportService = reportService;
            _blogDetailService = blogDetailService;
        }
        public BlogsController()
        {

        }

        [ResponseType(typeof(IEnumerable<Blog>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllBlogs()
        {
            var result = await _blogService.GetAllIncluding();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(IEnumerable<Blog>))]
        [HttpPost]
        public async Task<IHttpActionResult> GetAllBlogsByCategory(int? id)
        {
            var result = await _blogService.GetBlogByCategory(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(IEnumerable<Blog>))]
        [HttpPost]
        public async Task<IHttpActionResult> GetAllBlogsBySubcategory(int? id)
        {
            var result = await _blogService.GetBlogBySubcategory(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(Blog))]
        [HttpGet]
        public async Task<IHttpActionResult> GetBlog(int? id)
        {
            var result = await _blogService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(Blog))]
        [HttpPost]
        public async Task<IHttpActionResult> HitRead(int? id)
        {
            var hit = await _blogService.HitRead(id);
            if (hit != null)
            {
                return Ok(hit);
            }
            return BadRequest();
        }

        [ResponseType(typeof(Blog))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateBlog(Blog model, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else if (image == null && image.ContentLength < 0)
            {
                return BadRequest();
            }
            else
            {
                if (image != null && image.ContentLength > 0)
                {
                    var path = Path.GetExtension(image.FileName);
                    var photoName = Guid.NewGuid() + path;
                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "~/img/blog/" + photoName);
                    var stream = new FileStream(upload, FileMode.Create);
                    image.InputStream.CopyTo(stream);
                    model.Photo = photoName;
                }
                await _blogService.Create(model);
                return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
            }
        }

        [ResponseType(typeof(Blog))]
        [HttpPut]
        public async Task<IHttpActionResult> EditBlog(int? id, Blog model, HttpPostedFileBase image)
        {
            var updateBlog = await _blogService.GetById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (updateBlog == null)
            {
                return BadRequest();
            }
            else
            {
                if (image != null && image.ContentLength > 0)
                {
                    var path = Path.GetExtension(image.FileName);
                    var photoName = Guid.NewGuid() + path;
                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "~/img/blog/" + photoName);
                    var stream = new FileStream(upload, FileMode.Create);
                    image.InputStream.CopyTo(stream);
                    model.Photo = photoName;
                }
                await _blogService.Update(model);
                return Ok();
            }
        }

        [ResponseType(typeof(Blog))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateReport(int? id, string namesurname, string email, string phonenumber, string subject, string text)
        {
            var blogId = await _reportService.GetById(id);
            if (blogId != null)
            {
                Report model = new Report
                {
                    BlogId = id,
                    NameSurname = namesurname,
                    EmailAddress = email,
                    PhoneNumber = phonenumber,
                    Subject = subject,
                    Text = text
                };
                await _reportService.Create(model);
                return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
            }
            return BadRequest();
        }

        [ResponseType(typeof(BlogDetail))]
        [HttpPost]
        public async Task<IHttpActionResult> CrateBlogDetail(int? id, string subdetail, string text)
        {
            var blogId = await _reportService.GetById(id);
            if (blogId != null)
            {
                BlogDetail model = new BlogDetail
                {
                    BlogId = id,
                    Subdetail = subdetail,
                    Text = text
                };
                await _blogDetailService.Create(model);
                return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
            }
            return BadRequest();
        }

        [ResponseType(typeof(Blog))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAbout(int id)
        {
            var deleteBlog = await _blogService.GetById(id);
            if (deleteBlog == null)
            {
                return NotFound();
            }
            else
            {
                await _blogService.Delete(deleteBlog);
            }
            return Ok(deleteBlog);
        }

        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> SetActiveBlog(int id)
        {
            var blog = await _blogService.GetById(id);
            if (blog != null)
            {
                await _blogService.SetActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> SetDeActiveBlog(int id)
        {
            var blog = await _blogService.GetById(id);
            if (blog != null)
            {
                await _blogService.SetDeActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> DeletedBlog(int id)
        {
            var blog = await _blogService.GetById(id);
            if (blog != null)
            {
                await _blogService.Deleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> NotDeletedBlog(int id)
        {
            var blog = await _blogService.GetById(id);
            if (blog != null)
            {
                await _blogService.UnDeleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
