using AutoMapper;
using Restaurant.BLL.Dtos.CartItemDtos;
using Restaurant.BLL.Dtos.OrderItemDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    public class OrderItemAutoMapper : Profile
    {
        public OrderItemAutoMapper()
        {
            CreateMap<OrderItem, OrderItemCreateDto>().ReverseMap().ForMember(x => x.Product, x => x.Ignore()).ForMember(x => x.TotalPrice, x => x.MapFrom(x => x.Product.Price));
            CreateMap<OrderItem, OrderItemUpdateDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemGetDto>().ReverseMap();
            CreateMap<OrderItemCreateDto,CartItemGetDto>().ReverseMap();
            CreateMap<OrderItemGetDto, CartItemGetDto>().ReverseMap().ForMember(x => x.TotalPrice, x => x.MapFrom(x => x.Product.Price));
        }
    }
}
