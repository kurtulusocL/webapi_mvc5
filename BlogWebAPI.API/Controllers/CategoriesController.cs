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
    [Authorize(Roles ="Admin")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public CategoriesController()
        {

        }

        [AllowAnonymous]
        [ResponseType(typeof(IEnumerable<Category>))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [AllowAnonymous]
        [ResponseType(typeof(Category))] 
        [HttpGet]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        [ResponseType(typeof(Category))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateCategory([FromBody] Category model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _categoryService.Create(model);

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> EditCategory([FromBody] int? id, Category model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != model.Id)
            {
                return BadRequest();
            }
            else
            {
                await _categoryService.Update(model);
                return Ok();
            }
        }

        [ResponseType(typeof(Category))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCategory(int id)
        {
            var deleteCategory = await _categoryService.GetById(id);
            if (deleteCategory == null)
            {
                return NotFound();
            }
            else
            {
                await _categoryService.Delete(deleteCategory);
            }
            return Ok(deleteCategory);
        }

        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> SetActiveCategory(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category != null)
            {
                await _categoryService.SetActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> SetDeActiveCategory(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category != null)
            {
                await _categoryService.SetDeActive(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeletedCategory(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category != null)
            {
                await _categoryService.Deleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> NotDeletedCategory(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category != null)
            {
                await _categoryService.UnDeleted(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
