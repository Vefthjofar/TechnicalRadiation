using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.InputModels;
using System;

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

        public AuthorDetailDto GetAuthorById(int id)
        {
            var entity = DataProvider.Authors.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return null; /* throw some exception */ }
            return _mapper.Map<AuthorDetailDto>(entity);
        }

         public IEnumerable<NewsItemDto> GetAllNewsItemsByAuthor(int id)
        {
            IEnumerable<NewsItemAuthor> items = DataProvider.NewsItemAuthor.Where(r => r.AuthorId == id);
            List<NewsItem> newsItems = new List<NewsItem>();
            foreach (var i in items)
            {
                newsItems.Add(DataProvider.NewsItems.FirstOrDefault(r => r.Id == i.NewsItemId));
            }
            newsItems.OrderByDescending(r => r.PublishDate);

            return _mapper.Map<IEnumerable<NewsItemDto>>(newsItems);

        }
        
        public AuthorDto CreateNewAuthor(AuthorInputModel author)
        {
            var nextId = DataProvider.Authors.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
            var entity = _mapper.Map<Author>(author);
            entity.Id = nextId;
            DataProvider.Authors.Add(entity);
            return _mapper.Map<AuthorDto>(entity);
            
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var entity = DataProvider.Authors.FirstOrDefault(r => r.Id == id);
            if(entity == null) { return;}


            entity.Name = author.Name;
            entity.ProfileImgSource = author.ProfileImgSource;
            entity.Bio = author.bio;
            entity.ModifiedDate = DateTime.Now;
        }

        public void DeleteAuthorById(int id)
        {
            var entity = DataProvider.Authors.FirstOrDefault(r => r.Id == id);
            if(entity == null) { return;}
            DataProvider.Authors.Remove(entity);
        }

        public bool LinkAuthorToNewsItem(int authorId, int newsItemId)
        {
            var authorEntity = DataProvider.Authors.FirstOrDefault(r => r.Id == authorId);
            var newsItemEntity = DataProvider.NewsItems.FirstOrDefault(r => r.Id == newsItemId);
            if(newsItemEntity == null || authorEntity == null){return false;}
            IEnumerable<NewsItemAuthor> items = DataProvider.NewsItemAuthor.Where(r => r.AuthorId == authorId);
            foreach(var i in items)
            {
                if(i.NewsItemId == newsItemId) {return true;}
            }
            var entity = new NewsItemAuthor
            {
                AuthorId = authorId,
                NewsItemId = newsItemId
            };
            DataProvider.NewsItemAuthor.Add(entity);
            return true;
        }

        public List<AuthorDetailDto> GetAuthorsOfNewsItem(int newsItemId)
        {
             List<AuthorDetailDto> authors = new List<AuthorDetailDto>();
             var newsItemAuthors = DataProvider.NewsItemAuthor.Where(r => r.NewsItemId == newsItemId);
             foreach(var i in newsItemAuthors)
             {
                 authors.Add(GetAuthorById(i.AuthorId));
             }
             return authors;
        }
    }
}