using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        private AuthorService _authorService;
        private AuthenticationService _authenticationService;

        public AuthorController(IMapper mapper)
        {
            _authorService = new AuthorService(mapper);
            _authenticationService = new AuthenticationService();
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors().ToList();
            return Ok(authors);
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetAuthorById")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            return Ok(author);
        }


        [HttpGet]
        [Route("{id:int}/newsItems", Name = "GetAuthorsNewsItems")]
        public IActionResult GetAuthorsNewsItems(int id)
        {
            var newsItems = _authorService.getAllNewsItemsByAuthorId(id);
            return Ok(newsItems);
        }

        [Route("")]
        [HttpPost]
        public IActionResult CreateNewAuthor([FromBody] AuthorInputModel body)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            
            var entity = _authorService.CreateNewAuthor(body);

            return CreatedAtRoute("GetAuthorById", new { id = entity.Id }, null);
        }

        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateAuthorById([FromBody] AuthorInputModel author, int id)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }

            _authorService.UpdateAuthorById(author, id);

            return NoContent();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteAuthorById(int id)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            _authorService.DeleteAuthorById(id);
            return NoContent();
        }
         
        [Route("{authorId:int}/newsItems/{newsItemId:int}", Name = "LinkAuthorToNewsItem")]
        [HttpPost]
        public IActionResult LinkAuthorToNewsItem(int authorId, int newsItemId)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}

            var ans = _authorService.LinkAuthorToNewsItem(authorId, newsItemId);
            if(!ans){ return BadRequest("no such author or newsItem");}
            return NoContent();
        }
    }
}