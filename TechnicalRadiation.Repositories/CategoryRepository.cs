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
    }
}