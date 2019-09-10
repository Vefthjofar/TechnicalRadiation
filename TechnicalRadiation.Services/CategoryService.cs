using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class CategoryService
    {
        private CategoryRepository _CategoryRepository;

        public CategoryService(IMapper mapper)
        {
            _CategoryRepository = new CategoryRepository(mapper);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _CategoryRepository.GetAllCategories().ToList();
            return categories;
        }
        
    }
}