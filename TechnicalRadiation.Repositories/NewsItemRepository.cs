﻿using System;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Repositories.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Entities;

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


        public NewsItemDetailDto GetNewsById(int id)
        {
            var entity = DataProvider.NewsItems.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return null; /* throw some exception */ }
            return _mapper.Map<NewsItemDetailDto>(entity);
        }

        public NewsItemDto CreateNewNewsitem(NewsItemInputModel newsItem)
        {
            var nextId = DataProvider.NewsItems.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
            var entity = _mapper.Map<NewsItem>(newsItem);
            entity.Id = nextId;
            DataProvider.NewsItems.Add(entity);
            return _mapper.Map<NewsItemDto>(entity);
        }
        public void UpdateNewsItemById(NewsItemInputModel newsItem, int id)
        {
            var entity = DataProvider.NewsItems.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; /* Throw some exception */ }

            // Update properties
            entity.Title = newsItem.Title;
            entity.ImgSource = newsItem.ImgSource;
            entity.LongDescription = newsItem.LongDescription;
            entity.ModifiedBy = "Admin";
            entity.ModifiedDate = DateTime.Now;
            entity.PublishDate = newsItem.PublishDate;
            entity.ShortDescription = newsItem.ShortDescription;

        }
        public void DeleteNewsItemById(int id)
        {
            var entity = DataProvider.NewsItems.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; }
            DataProvider.NewsItems.Remove(entity);
        }
    }
}
