using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories
{
    public class CategoryRepository
    {
        private IMapper _mapper;
        public CategoryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(DataProvider.Categories);
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            var entity = DataProvider.Categories.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return null; /* throw some exception */ }
            return _mapper.Map<CategoryDetailDto>(entity);
        }
        
        public CategoryDto CreateNewCategory(CategoryInputModel category)
        {
            var nextId = DataProvider.Categories.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
            var entity = _mapper.Map<Category>(category);

            entity.Id = nextId;
            entity.Slug = entity.Name.ToLower().Replace(' ', '-');
            DataProvider.Categories.Add(entity);
            return _mapper.Map<CategoryDto>(entity);
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var entity = DataProvider.Categories.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; /* Throw some exception */ }

            // Update properties
            entity.Name = category.Name;
            // Maybe do this in the mapping profile?
            entity.Slug = category.Name.ToLower().Replace(' ', '-');
        }

        public void DeleteCategoryById(int id)
        {
            var entity = DataProvider.Categories.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; }
            DataProvider.Categories.Remove(entity);
        }

        public bool ConnectNewsItemToCategory(int categoryId, int newsItemId)
        {
            var categoryEntity = DataProvider.Categories.FirstOrDefault(r => r.Id == categoryId);
            var newsItemEntity = DataProvider.Categories.FirstOrDefault(r => r.Id == newsItemId);
            if (categoryEntity == null || newsItemEntity == null) { return false; }

            NewsItemCategories newsItemCategory = new NewsItemCategories
            {
                CategoryId = categoryEntity.Id,
                NewsItemId = newsItemEntity.Id
            };
            DataProvider.NewsItemCategories.Add(newsItemCategory);
            return true;
        }

        public IEnumerable<int> getCategoriesForNewsItem(int id)
        {
            IEnumerable<NewsItemCategories> items = DataProvider.NewsItemCategories.Where(r => r.NewsItemId == id);
            List<int> categories = new List<int>();
            foreach (var i in items)
            {
                categories.Add(i.CategoryId);
            }
            return categories;
        }
    }
}