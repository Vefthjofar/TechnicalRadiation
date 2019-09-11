using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Models.HyperMedia;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper)
        {
            _categoryRepository = new CategoryRepository(mapper);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories().ToList();
            categories.ForEach( c => {
                c.Links.AddReference("self", new {href = $"/api/categories/{c.Id}"} );
                c.Links.AddReference("edit", new {href = $"/api/categories/{c.Id}"} );
                c.Links.AddReference("delete", new {href = $"/api/categories/{c.Id}"} );
            });
            return categories;
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            category.Links.AddReference("self", new {href = $"/api/categories/{id}"} );
            category.Links.AddReference("edit", new {href = $"/api/categories/{id}"} );
            category.Links.AddReference("delete", new {href = $"/api/categories/{id}"} );
            return category;
        }
        
        public CategoryDto CreateNewCategory(CategoryInputModel category)
        {
            return _categoryRepository.CreateNewCategory(category);
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            _categoryRepository.UpdateCategoryById(category, id);
        }

        public void DeleteCategoryById(int id)
        {
             _categoryRepository.DeleteCategoryById(id);
        }

        public bool ConnectNewsItemToCategory(int categoryId, int newsItemId)
        {
            var success = _categoryRepository.ConnectNewsItemToCategory(categoryId, newsItemId);
            return success;
        }
        
    }
}