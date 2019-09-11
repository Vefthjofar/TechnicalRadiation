using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class AuthorRepository
    {
        private IMapper _mapper;
        public AuthorRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            return _mapper.Map<IEnumerable<AuthorDto>>(DataProvider.Authors);
        }
        public IEnumerable<NewsItem> GetAllNewsItemsByAuthor(int id)
        {
            var ids = _mapper.Map<IEnumerable<NewsItemAuthor>>(DataProvider.NewsItemAuthor.OrderByDescending(r => r.AuthorId == id));
            List<NewsItem> newsItems = new List<NewsItem>();
            foreach (var i in ids)
            {
                newsItems.Add(DataProvider.NewsItems.FirstOrDefault(r => r.Id == i.NewsItemId));
            }

            return newsItems;

        }



        public AuthorDto GetAuthorById(int id)
        {
            var entity = DataProvider.Authors.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return null; /* throw some exception */ }
            return _mapper.Map<AuthorDto>(entity);
        }
    }
}