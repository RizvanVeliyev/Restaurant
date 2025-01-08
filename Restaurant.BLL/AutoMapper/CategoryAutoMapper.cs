using AutoMapper;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class CategoryAutoMapper : Profile
    {
        public CategoryAutoMapper()
        {
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryGetDto>()
                                .ForMember(x => x.Name, x => x.MapFrom(x => x.CategoryDetails.FirstOrDefault() != null ? x.CategoryDetails.FirstOrDefault()!.Name : string.Empty));

            
                ;

            CreateMap<Category, CategoryGetDto>()
                .ForMember(x => x.Name, x => x.MapFrom(x => x.CategoryDetails.FirstOrDefault() != null ? x.CategoryDetails.FirstOrDefault()!.Name : string.Empty));
        }
    }
}
