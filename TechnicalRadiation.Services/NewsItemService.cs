using System.Collections.Generic;
using System.Linq;
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
            _newsItemRepository = new NewsItemRepository(mapper);
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            var newsItems = _newsItemRepository.GetAllNewsItems().ToList();
            return newsItems;
        }
        public NewsItemDto GetNewsById(int id)
        {
            var newsItem = _newsItemRepository.GetNewsById(id);
            return newsItem;
        }
    }
}