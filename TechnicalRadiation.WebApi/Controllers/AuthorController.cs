using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        private AuthorService _authorService;
        
        public AuthorController(IMapper mapper)
        {
            _authorService = new AuthorService(mapper);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors().ToList();
            return Ok(authors);
        }
    }
}