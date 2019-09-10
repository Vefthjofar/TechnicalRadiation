using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;

        public CategoryController(IMapper mapper)
        {
            _categoryService = new CategoryService(mapper);
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
    }
}