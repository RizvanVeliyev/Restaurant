using AutoMapper;
using Restaurant.BLL.Dtos.OrderDtos;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.AutoMapper
{
    public class OrderAutoMapper : Profile
    {
        public OrderAutoMapper()
        {
            CreateMap<Order, OrderCreateDto>().ReverseMap().ForMember(x => x.TotalPrice, x => x.MapFrom(x => x.OrderItems.Sum(x => x.Product.Price * x.Count)));
            CreateMap<Order, OrderUpdateDto>().ReverseMap();
            CreateMap<Order, OrderGetDto>().ReverseMap();
        }
    }
}
