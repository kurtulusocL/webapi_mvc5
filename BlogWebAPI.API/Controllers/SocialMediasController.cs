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
    public class SocialMediasController : ApiController
    {
        private readonly ISocialMediaService _socialMediaService;
        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public SocialMediasController()
        {

        }

        [ResponseType(typeof(IEnumerable<SocialMedia>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllSocialMedias()
        {
            var result = await _socialMediaService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(SocialMedia))]
        [HttpGet]
        public async Task<IHttpActionResult> GetSocialMedia(int? id)
        {
            var result = await _socialMediaService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(SocialMedia))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateSocialMedia(SocialMedia model, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (image == null && image.ContentLength < 0)
            {
                return BadRequest();
            }
            else
            {
                if (image != null && image.ContentLength > 0)
                {
                    var path = Path.GetExtension(image.FileName);
                    var photoName = Guid.NewGuid() + path;
                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "~/img/social/" + photoName);
                    var stream = new FileStream(upload, FileMode.Create);
                    image.InputStream.CopyTo(stream);
                    model.Logo = photoName;
                }
                await _socialMediaService.Create(model);
                return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
            }
        }

        [ResponseType(typeof(SocialMedia))]
        [HttpPut]
        public async Task<IHttpActionResult> EditSocialMedia(int? id, SocialMedia model, HttpPostedFileBase image)
        {
            var updateSocialMedia = await _socialMediaService.GetById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (updateSocialMedia == null)
            {
                return BadRequest();
            }
            else
            {
                if (image != null && image.ContentLength > 0)
                {
                    var path = Path.GetExtension(image.FileName);
                    var photoName = Guid.NewGuid() + path;
                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "~/img/social/" + photoName);
                    var stream = new FileStream(upload, FileMode.Create);
                    image.InputStream.CopyTo(stream);
                    model.Logo = photoName;
                }
                await _socialMediaService.Update(model);
                return Ok();
            }
        }

        [ResponseType(typeof(SocialMedia))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteSocial(int id)
        {
            var deleteSocial = await _socialMediaService.GetById(id);
            if (deleteSocial == null)
            {
                return NotFound();
            }
            else
            {
                await _socialMediaService.Delete(deleteSocial);
            }
            return Ok(deleteSocial);
        }

        [ResponseType(typeof(SocialMedia))]
        public async Task<IHttpActionResult> SetActiveSocial(int id)
        {
            var social = await _socialMediaService.GetById(id);
            if (social != null)
            {
                await _socialMediaService.SetActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(SocialMedia))]
        public async Task<IHttpActionResult> SetDeActiveSocial(int id)
        {
            var social = await _socialMediaService.GetById(id);
            if (social != null)
            {
                await _socialMediaService.SetDeActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(SocialMedia))]
        public async Task<IHttpActionResult> DeletedSocial(int id)
        {
            var social = await _socialMediaService.GetById(id);
            if (social != null)
            {
                await _socialMediaService.Deleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(SocialMedia))]
        public async Task<IHttpActionResult> NotDeletedAbout(int id)
        {
            var social = await _socialMediaService.GetById(id);
            if (social != null)
            {
                await _socialMediaService.UnDeleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
