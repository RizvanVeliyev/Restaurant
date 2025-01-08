using AutoMapper;
using Restaurant.BLL.Dtos.CartItemDtos;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
