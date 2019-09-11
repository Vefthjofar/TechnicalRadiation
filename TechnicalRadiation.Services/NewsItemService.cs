using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            var newsItems = _newsItemRepository.GetAllNewsItems().ToList();
            newsItems.ForEach(r => {
                r.Links.AddReference("self", $"/api/{r.Id}");
                r.Links.AddReference("edit", $"/api/{r.Id}");
                r.Links.AddReference("delete", $"/api/{r.Id}");
                r.Links.AddListReference("authors", _authorRepository.GetAuthorsOfNewsItem(r.Id).Select(a => new { href = $"/api/authors/{a.Id}"}));
                r.Links.AddListReference("categories", _categoryRepository.getCategoriesForNewsItem(r.Id).Select(c => new { href = $"/api/categories/{c}"}));
            });

            return newsItems;
        }
        public NewsItemDetailDto GetNewsById(int id)
        {
            var newsItem = _newsItemRepository.GetNewsById(id);
            newsItem.Links.AddReference("self", $"/api/{newsItem.Id}");
            newsItem.Links.AddReference("edit", $"/api/{newsItem.Id}");
            newsItem.Links.AddReference("delete", $"/api/{newsItem.Id}");
            newsItem.Links.AddListReference("authors", _authorRepository.GetAuthorsOfNewsItem(newsItem.Id).Select(a => new { href = $"/api/authors/{a.Id}"}));
            newsItem.Links.AddListReference("categories", _categoryRepository.getCategoriesForNewsItem(newsItem.Id).Select(c => new { href = $"/api/categories/{c}"}));
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