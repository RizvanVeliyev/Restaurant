using AutoMapper;
using Restaurant.BLL.Dtos.BlogDetailDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class BlogDetailAutoMapper : Profile
    {
        public BlogDetailAutoMapper()
        {
            CreateMap<BlogDetail, BlogDetailCreateDto>().ReverseMap();
            CreateMap<BlogDetail, BlogDetailUpdateDto>().ReverseMap();
        }
    }
}
