using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dto;
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
            return categories;
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
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
        
    }
}