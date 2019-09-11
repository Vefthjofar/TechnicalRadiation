using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services
{
    public class AuthorService
    {
        private AuthorRepository _authorRepository;

        public AuthorService(IMapper mapper)
        {
            _authorRepository = new AuthorRepository(mapper);
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors().ToList();
            return authors;
        }
        public AuthorDetailDto GetAuthorById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            return author;
        }

        public IEnumerable<NewsItem> getAllNewsItemsByAuthorId(int id)
        {

            var newsItems = _authorRepository.GetAllNewsItemsByAuthor(id);

            return newsItems;
        }

        public AuthorDto CreateNewAuthor(AuthorInputModel author)
        {
            return _authorRepository.CreateNewAuthor(author);
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            _authorRepository.UpdateAuthorById(author,id);
        }
        public void DeleteAuthorById(int id)
        {
            _authorRepository.DeleteAutorById(id);
        }

        public bool LinkAuthorToNewsItem(int authorId, int newsItemId)
        {
            var ans = _authorRepository.LinkAuthorToNewsItem(authorId, newsItemId);
            return ans;
        }
    }
}