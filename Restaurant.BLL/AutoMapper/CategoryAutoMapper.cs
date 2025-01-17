using AutoMapper;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.UI.Dtos;
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

            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            //CreateMap<Category, CategoryWithProductsDto>()
            //                    .ForMember(x => x.CategoryName, x => x.MapFrom(x => x.CategoryDetails.FirstOrDefault() != null ? x.CategoryDetails.FirstOrDefault()!.Name : string.Empty))
            //                    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));



        }
    }
}
