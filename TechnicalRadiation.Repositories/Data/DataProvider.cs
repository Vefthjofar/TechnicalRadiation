    
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
                PublishDate = "1/1/2015",
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            }
        };
    }
}