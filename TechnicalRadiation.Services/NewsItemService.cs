using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.HyperMedia;

namespace TechnicalRadiation.Services
{
    public class NewsItemService
    {
        private NewsItemRepository _newsItemRepository;
        private AuthorRepository _authorRepository;
        private CategoryRepository _categoryRepository;

        public NewsItemService(IMapper mapper)
        {
            _newsItemRepository = new NewsItemRepository(mapper);
            _authorRepository = new AuthorRepository(mapper);
            _categoryRepository = new CategoryRepository(mapper);
        }
        /* rentals.ForEach(r => {
                r.Links.AddReference("self", $"/api/rentals/{r.Id}");
                r.Links.AddListReference("owners", _ownerRepository.GetOwnersByRentalId(r.Id).Select(o => new { href = $"/api/rentals/{r.Id}/owners/{o.Id}" }));
            }); */
        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            var newsItems = _newsItemRepository.GetAllNewsItems().ToList();
            newsItems.ForEach(r => {
                r.Links.AddReference("self", $"/api/{r.Id}");
                r.Links.AddReference("edit", $"/api/{r.Id}");
                r.Links.AddReference("delete", $"/api/{r.Id}");
                /* for each author in returned list, create href */
                r.Links.AddListReference("authors", _authorRepository.GetAuthorsOfNewsItem(r.Id).Select(a => new { href = $"/api/authors/{a.Id}"})); //$"/api/authors/{r.Id}"
            });

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