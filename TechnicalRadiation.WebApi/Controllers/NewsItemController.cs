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
    [Route("api/")]
    public class NewsItemController : Controller
    {
        private NewsItemService _newsItemService;
        private AuthenticationService _authenticationService;

        public NewsItemController(IMapper mapper)
        {
            _newsItemService = new NewsItemService(mapper);
            _authenticationService = new AuthenticationService();
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAllNewsItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {
            var newsItems = _newsItemService.GetAllNewsItems().ToList();
            var envelope = new Envelope<NewsItemDto>(pageNumber, pageSize, newsItems);
            return Ok(envelope);
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetNewsById")]
        public IActionResult GetNewsById(int id)
        {
            var newsItem = _newsItemService.GetNewsById(id);
            return Ok(newsItem);
        }

        [Route("")]
        [HttpPost]
        public IActionResult CreateNewNewsItem([FromBody] NewsItemInputModel body)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            
            var entity = _newsItemService.CreateNewNewsItem(body);

            return CreatedAtRoute("GetNewsById", new { id = entity.Id }, null);
        }
        
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateNewsItemById([FromBody] NewsItemInputModel newsItem, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }

            _newsItemService.UpdateNewsItemById(newsItem, id);

            return NoContent();
        }
        
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteNewsItemById(int id)
        {
            if(!_authenticationService.isValidToken(Request.Headers["Authorization"])) {return Unauthorized();}
            _newsItemService.DeleteNewsItemById(id);
            return NoContent();
        }
    }
}