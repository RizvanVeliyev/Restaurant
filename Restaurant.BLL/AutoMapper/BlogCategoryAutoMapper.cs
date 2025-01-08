using AutoMapper;
using Restaurant.BLL.Dtos.BlogCategoryDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class BlogCategoryAutoMapper : Profile
    {
        public BlogCategoryAutoMapper()
        {
            CreateMap<BlogCategory, BlogCategoryCreateDto>().ReverseMap();
            CreateMap<BlogCategory, BlogCategoryGetDto>()
                                .ForMember(x => x.Name, x => x.MapFrom(x => x.BlogCategoryDetails.FirstOrDefault() != null ? x.BlogCategoryDetails.FirstOrDefault()!.Name : string.Empty));


            ;

            CreateMap<BlogCategory, BlogCategoryGetDto>()
                .ForMember(x => x.Name, x => x.MapFrom(x => x.BlogCategoryDetails.FirstOrDefault() != null ? x.BlogCategoryDetails.FirstOrDefault()!.Name : string.Empty));
        }
    }
}
