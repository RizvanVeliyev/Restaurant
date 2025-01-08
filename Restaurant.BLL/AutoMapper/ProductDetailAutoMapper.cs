using AutoMapper;
using Restaurant.BLL.Dtos.ProductDetailDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class ProductDetailAutoMapper : Profile
    {
        public ProductDetailAutoMapper()
        {
            CreateMap<ProductDetail, ProductDetailCreateDto>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailUpdateDto>().ReverseMap();
        }
    }
}
