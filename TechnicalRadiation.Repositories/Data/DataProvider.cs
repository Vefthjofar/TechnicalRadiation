
using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public static class DataProvider
    {
        private static readonly string _adminName = "Admin";

        public static List<NewsItem> NewsItems = new List<NewsItem>
        {
            new NewsItem
            {
                Id = 0,
                Title = "Title of news Article",
                ImgSource = "https://example.com/news-item/1.jpg",
                ShortDescription = "Short description for the news item",
                LongDescription = "Long description for the news item",
                PublishDate = DateTime.Parse("12/09/2002 10:10:10"),
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new NewsItem
            {
                Id = 1,
                Title = "Title of news Article2",
                ImgSource = "https://example.com/news-item/1.jpg",
                ShortDescription = "Short description for the news item",
                LongDescription = "Long description for the news item",
                PublishDate = DateTime.Parse("12/09/2003 10:10:10"),
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            }
        };
        public static List<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = 0,
                Name = "Gadgets",
                Slug = "gadgets",
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category
            {
                Id = 1,
                Name = "Software",
                Slug = "software",
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category
            {
                Id = 2,
                Name = "Computers",
                Slug = "computers",
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Category
            {
                Id = 3,
                Name = "New Technologies",
                Slug = "new-technologies",
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
        };
        public static List<Author> Authors = new List<Author>
        {
            new Author
            {
                Id = 0,
                Name = "Gandalf",
                ProfileImgSource = "https://en.wikipedia.org/wiki/Gandalf#/media/File:Gandalf600ppx.jpg",
                Bio = "the white",
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            }
        };

        public static List<NewsItemAuthor> NewsItemAuthor = new List<NewsItemAuthor>
        {
            new NewsItemAuthor
            {
                AuthorId = 0,
                NewsItemId = 0
            },
            new NewsItemAuthor
            {
                AuthorId = 0,
                NewsItemId = 1
            }
        };

        public static List<NewsItemCategories> NewsItemCategories = new List<NewsItemCategories>
        {};
    }
}