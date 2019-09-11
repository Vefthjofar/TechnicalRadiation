using System;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Entities;
using System.Globalization;

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
        
        public CategoryDto CreateNewCategory(CategoryInputModel category)
        {
            var nextId = DataProvider.Categories.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
            var entity = _mapper.Map<Category>(category);

            entity.Id = nextId;
            entity.Slug = entity.Name.ToLower().Replace(' ', '-');
            DataProvider.Categories.Add(entity);
            return _mapper.Map<CategoryDto>(entity);
        }
    }
}