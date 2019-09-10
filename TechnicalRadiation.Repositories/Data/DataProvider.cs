    
using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public static class DataProvider
    {
        private static readonly string _adminName = "NewsAdmin";

        public static List<NewsItem> NewsItems = new List<NewsItem>
        {
            new NewsItem
            {
                Id = 1,
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
                Id = 2,
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
    }
}