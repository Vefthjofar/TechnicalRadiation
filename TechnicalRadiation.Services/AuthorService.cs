using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.HyperMedia;

namespace TechnicalRadiation.Services
{
    public class AuthorService
    {
        private AuthorRepository _authorRepository;
        private CategoryRepository _categoryRepository;

        public AuthorService(IMapper mapper)
        {
            _authorRepository = new AuthorRepository(mapper);
            _categoryRepository = new CategoryRepository(mapper);
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors().ToList();
            authors.ForEach( a => {
                a.Links.AddReference("self", new {href = $"/api/authors/{a.Id}"} );
                a.Links.AddReference("edit", new {href = $"/api/authors/{a.Id}"} );
                a.Links.AddReference("delete", new {href = $"/api/authors/{a.Id}"} );
                a.Links.AddReference("newsItems", new { href = $"/api/authors/{a.Id}/newsItems"});
                a.Links.AddListReference("newsItemsDetailed", _authorRepository.GetAllNewsItemsByAuthor(a.Id)
                .Select(o => new { href = $"/api/newsItems/{o.Id}" }));
            });
            return authors;
        }
        public AuthorDetailDto GetAuthorById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            author.Links.AddReference("self", new {href = $"/api/authors/{author.Id}"} );
            author.Links.AddReference("edit", new {href = $"/api/authors/{author.Id}"} );
            author.Links.AddReference("delete", new {href = $"/api/authors/{author.Id}"} );
            author.Links.AddReference("newsItems", new {href = $"/api/authors/{author.Id}/newsItems"} );
            author.Links.AddListReference("newsItemsDetailed", _authorRepository.GetAllNewsItemsByAuthor(id)
            .Select(o => new { href = $"/api/newsItems/{o.Id}" }));

            return author;
        }

        public IEnumerable<NewsItemDto> getAllNewsItemsByAuthorId(int id)
        {

            var newsItems = _authorRepository.GetAllNewsItemsByAuthor(id);
            foreach (var n in newsItems)
            {
                n.Links.AddReference("self", new {href = $"/api/{n.Id}"} );
                n.Links.AddReference("edit", new {href = $"/api/{n.Id}"} );
                n.Links.AddReference("delete", new {href = $"/api/{n.Id}"} );
                // finna authors
                n.Links.AddListReference("authors", _authorRepository.GetAuthorsOfNewsItem(n.Id)
                .Select(o => new { href = $"/api/authors/{o.Id}"}));
                // finna öll category id
                n.Links.AddListReference("categories",  _categoryRepository.getCategoriesForNewsItem(n.Id)
                .Select(o => new { href = $"/api/categories/{o}" }));
            }

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
            _authorRepository.DeleteAuthorById(id);
        }

        public bool LinkAuthorToNewsItem(int authorId, int newsItemId)
        {
            var ans = _authorRepository.LinkAuthorToNewsItem(authorId, newsItemId);
            return ans;
        }
    }
}