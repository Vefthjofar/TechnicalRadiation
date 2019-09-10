using System;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

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

        public CategoryDto GetCategoryById(int id)
        {
            var entity = DataProvider.Categories.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return null; /* throw some exception */ }
            return _mapper.Map<CategoryDto>(entity);
        }
    }
}