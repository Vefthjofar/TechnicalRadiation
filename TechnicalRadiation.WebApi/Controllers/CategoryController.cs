using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dto;
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
    }
}