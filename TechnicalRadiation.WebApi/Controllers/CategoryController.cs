using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;

        private AuthenticationService _authenticationService;

        public CategoryController(IMapper mapper)
        {
            _categoryService = new CategoryService(mapper);
            _authenticationService = new AuthenticationService();
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories().ToList());
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return Ok(category);
        }

        [Route("")]
        [HttpPost]
        public IActionResult CreateNewCategory([FromBody] CategoryInputModel body)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }

            var entity = _categoryService.CreateNewCategory(body);

            return CreatedAtRoute("GetCategoryById", new { id = entity.Id }, null);
        }

        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateCategoryById([FromBody] CategoryInputModel category, int id)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }

            _categoryService.UpdateCategoryById(category, id);

            return Ok();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteCategoryById(int id)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            _categoryService.DeleteCategoryById(id);
            return NoContent();
        }

        [Route("{categoryId:int}/newsItems/{newsItemId:int}")]
        [HttpPost]
        public IActionResult ConnectNewsItemToCategory(int categoryId, int newsItemId)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }

            var success = _categoryService.ConnectNewsItemToCategory(categoryId, newsItemId);

            if (success) return Ok();
            else return BadRequest("One or both id's don't match any data.");
        }
    }
}