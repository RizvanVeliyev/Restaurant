using AutoMapper;
using Restaurant.BLL.Dtos.CartItemDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class CartItemAutoMapper : Profile
    {
        public CartItemAutoMapper()
        {
            CreateMap<CartItem, CartItemCreateDto>().ReverseMap();
            CreateMap<CartItem, CartItemGetDto>().ReverseMap();
        }
    }
}
