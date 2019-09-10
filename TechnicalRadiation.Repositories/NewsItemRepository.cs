using System;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace TechnicalRadiation.Repositories
{
    public class NewsItemRepository
    {
        private IMapper _mapper;
        public NewsItemRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            return _mapper.Map<IEnumerable<NewsItemDto>>(DataProvider.NewsItems.OrderByDescending(r => r.PublishDate));
        }
        
        public NewsItemDto GetNewsById(int id)
        {
            var entity = DataProvider.NewsItems.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return null; /* throw some exception */ }
            return _mapper.Map<NewsItemDto>(entity);
        }
    }
}
