using AutoMapper;
using Restaurant.BLL.Dtos.BlogDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class BlogAutoMapper : Profile
    {
        public BlogAutoMapper()
        {
            CreateMap<Blog, BlogCreateDto>().ReverseMap();

            CreateMap<Blog, BlogUpdateDto>()
                .ForMember(dto => dto.ImagePath, opt => opt.MapFrom(blog => blog.ImageUrl))
                .ReverseMap();

            CreateMap<Blog, BlogGetDto>()
                .ForMember(x => x.Name, x => x.MapFrom(src => src.BlogDetails.FirstOrDefault() != null ? src.BlogDetails.FirstOrDefault()!.Name : string.Empty))
                .ForMember(x => x.Description, x => x.MapFrom(src => src.BlogDetails.FirstOrDefault() != null ? src.BlogDetails.FirstOrDefault()!.Description : string.Empty))
                .ForMember(x => x.ImagePath, x => x.MapFrom(src => src.ImageUrl));
        }
    }
}
