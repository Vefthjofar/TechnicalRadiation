using AutoMapper;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Dto;
using TechnicalRadiation.Models.InputModels;
using System;

namespace TechnicalRadiation.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewsItem, NewsItemDto>();
            CreateMap<NewsItemInputModel, NewsItem>()
                .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "Admin"));
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryInputModel, Category>()
                .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "Admin"));
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorInputModel, Author>()
                .ForMember(src => src.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "Admin"));
        }
    }
}