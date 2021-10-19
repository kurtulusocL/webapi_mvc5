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
    public class ContactsController : ApiController
    {
        IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public ContactsController()
        {

        }

        [ResponseType(typeof(IEnumerable<Contact>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetContacts()
        {
            var result = await _contactService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [ResponseType(typeof(Category))]
        [HttpGet]
        public async Task<IHttpActionResult> GetContact(int? id)
        {
            var result = await _contactService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [ResponseType(typeof(Contact))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateContact(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await _contactService.Create(model);
            }
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(Contact))]
        [HttpPut]
        public async Task<IHttpActionResult> EditContact(int? id, Contact model)
        {
            var updateContact = await _contactService.GetById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else if (updateContact == null)
            {
                return BadRequest();
            }
            else
            {
                await _contactService.Update(model);
                return Ok(updateContact);
            }
        }

        [ResponseType(typeof(Contact))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            var deleteContact = await _contactService.GetById(id);
            if (deleteContact != null)
            {
                await _contactService.Delete(deleteContact);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> SetActiveContact(int id)
        {
            var contact = await _contactService.GetById(id);
            if (contact != null)
            {
                await _contactService.SetActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> SetDeActiveContact(int id)
        {
            var contact = await _contactService.GetById(id);
            if (contact != null)
            {
                await _contactService.SetDeActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeletedContact(int id)
        {
            var contact = await _contactService.GetById(id);
            if (contact != null)
            {
                await _contactService.Deleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> NotDeletedContact(int id)
        {
            var contact = await _contactService.GetById(id);
            if (contact != null)
            {
                await _contactService.UnDeleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
