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
    public class SubcategoriesController : ApiController
    {
        private readonly ISubcategoryService _subcategoryService;
        public SubcategoriesController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }
        public SubcategoriesController()
        {

        }

        [ResponseType(typeof(IEnumerable<Subcategory>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllSubcategories()
        {
            var result = await _subcategoryService.GetAllIncluding();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Subcategory))]
        [HttpGet]
        public async Task<IHttpActionResult> GetSubcategory(int? id)
        {
            var result = await _subcategoryService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Subcategory))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateSubcategory(Subcategory model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await _subcategoryService.Create(model);
            }
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(Subcategory))]
        [HttpPut]
        public async Task<IHttpActionResult> EditSubcategory(int? id, Subcategory model)
        {
            var updateSubcategory = await _subcategoryService.GetById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else if (updateSubcategory == null)
            {
                return BadRequest();
            }
            else
            {
                await _subcategoryService.Update(model);
                return Ok(updateSubcategory);
            }
        }

        [ResponseType(typeof(Subcategory))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteSubcategory(int? id)
        {
            var deleteSubcategory = await _subcategoryService.GetById(id);
            if (deleteSubcategory != null)
            {
                await _subcategoryService.Delete(deleteSubcategory);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> SetActiveSubcategory(int id)
        {
            var subcategory = await _subcategoryService.GetById(id);
            if (subcategory != null)
            {
                await _subcategoryService.SetActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> SetDeActiveSubcategory(int id)
        {
            var subcategory = await _subcategoryService.GetById(id);
            if (subcategory != null)
            {
                await _subcategoryService.SetDeActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeletedSubcategory(int id)
        {
            var subcategory = await _subcategoryService.GetById(id);
            if (subcategory != null)
            {
                await _subcategoryService.Deleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> NotDeletedSubcategory(int id)
        {
            var subcategory = await _subcategoryService.GetById(id);
            if (subcategory != null)
            {
                await _subcategoryService.UnDeleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
