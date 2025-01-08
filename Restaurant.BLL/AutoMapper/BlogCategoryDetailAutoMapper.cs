using AutoMapper;
using Restaurant.BLL.Dtos.BlogCategoryDetailDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class BlogCategoryDetailAutoMapper : Profile
    {
        public BlogCategoryDetailAutoMapper()
        {
            CreateMap<BlogCategoryDetail, BlogCategoryDetailCreateDto>().ReverseMap();
            CreateMap<BlogCategoryDetail, BlogCategoryDetailUpdateDto>().ReverseMap();
        }
    }
}
