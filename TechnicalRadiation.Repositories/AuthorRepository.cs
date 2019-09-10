using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public AuthorDto GetAuthorById(int id)
        {
            var entity = DataProvider.Authors.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return null; /* throw some exception */ }
            return _mapper.Map<AuthorDto>(entity);
        }
    }
}