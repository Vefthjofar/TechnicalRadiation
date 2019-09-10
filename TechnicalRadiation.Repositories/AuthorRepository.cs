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
    }
}