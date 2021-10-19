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
    public class AboutsController : ApiController
    {
        private readonly IAboutService _aboutService;
        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public AboutsController()
        {

        }

        [ResponseType(typeof(IEnumerable<About>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllAbouts()
        {
            var result = await _aboutService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(About))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAbout(int? id)
        {
            var result = await _aboutService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(About))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateAbout(About model, HttpPostedFileBase image)
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
                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "~/img/about/" + photoName);
                    var stream = new FileStream(upload, FileMode.Create);
                    image.InputStream.CopyTo(stream);
                    model.Photo = photoName;
                }
                await _aboutService.Create(model);
                return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
            }
        }

        [ResponseType(typeof(About))]
        [HttpPut]
        public async Task<IHttpActionResult> EditAbout(int? id, About model, HttpPostedFileBase image)
        {
            var updateAbout = await _aboutService.GetById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (updateAbout == null)
            {
                return BadRequest();
            }
            else
            {
                if (image != null && image.ContentLength > 0)
                {
                    var path = Path.GetExtension(image.FileName);
                    var photoName = Guid.NewGuid() + path;
                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "~/img/about/" + photoName);
                    var stream = new FileStream(upload, FileMode.Create);
                    image.InputStream.CopyTo(stream);
                    model.Photo = photoName;
                }
                await _aboutService.Update(model);
                return Ok();
            }
        }

        [ResponseType(typeof(About))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAbout(int id)
        {
            var deleteAbout = await _aboutService.GetById(id);
            if (deleteAbout == null)
            {
                return NotFound();
            }
            else
            {
                await _aboutService.Delete(deleteAbout);
            }
            return Ok(deleteAbout);
        }

        [ResponseType(typeof(About))]
        public async Task<IHttpActionResult> SetActiveAbout(int id)
        {
            var about = await _aboutService.GetById(id);
            if (about != null)
            {
                await _aboutService.SetActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(About))]
        public async Task<IHttpActionResult> SetDeActiveAbout(int id)
        {
            var about = await _aboutService.GetById(id);
            if (about != null)
            {
                await _aboutService.SetDeActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(About))]
        public async Task<IHttpActionResult> DeletedAbout(int id)
        {
            var about = await _aboutService.GetById(id);
            if (about != null)
            {
                await _aboutService.Deleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(About))]
        public async Task<IHttpActionResult> NotDeletedAbout(int id)
        {
            var about = await _aboutService.GetById(id);
            if (about != null)
            {
                await _aboutService.UnDeleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
