using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services
{
    public class NewsItemService
    {
        private NewsItemRepository _newsItemRepository;

        public NewsItemService(IMapper mapper)
        {
            _newsItemRepository = new NewsItemRepository(mapper);
        }
        /* rentals.ForEach(r => {
                r.Links.AddReference("self", $"/api/rentals/{r.Id}");
                r.Links.AddListReference("owners", _ownerRepository.GetOwnersByRentalId(r.Id).Select(o => new { href = $"/api/rentals/{r.Id}/owners/{o.Id}" }));
            }); */
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

        public NewsItemDto CreateNewNewsItem(NewsItemInputModel newsItem)
        {
            return _newsItemRepository.CreateNewNewsitem(newsItem);
        }

        public void UpdateNewsItemById(NewsItemInputModel newsItem, int id)
        {
            _newsItemRepository.UpdateNewsItemById(newsItem, id);
        }
        public void DeleteNewsItemById(int id)
        {
             _newsItemRepository.DeleteNewsItemById(id);
        }

    }
}