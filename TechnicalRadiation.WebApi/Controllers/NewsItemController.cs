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
    [Route("api/")]
    public class NewsItemController : Controller
    {
        private NewsItemService _newsItemService;

        public NewsItemController(IMapper mapper)
        {
            _newsItemService = new NewsItemService();
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAllNewsItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {
            
            var envelope = new Envelope<NewsItemDto>(pageNumber, pageSize, listi);
            return Ok(envelope);
        }
    }
}