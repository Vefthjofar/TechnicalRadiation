using System.Collections.Generic;
using AutoMapper;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class NewsItemService
    {
        private NewsItemRepository _newsItemRepository;

        public NewsItemService(IMapper mapper)
        {
            _newsItemRepository = new NewsItemRepository();
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            var newsItems = _newsItemRepository.GetAllNewsItems().toList;
            return newsItems;
        }
    }
}