using AutoMapper;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.AutoMapper
{
    internal class SubscribeAutoMapper : Profile
    {
        public SubscribeAutoMapper()
        {
            CreateMap<Subscribe, SubscribeCreateDto>().ReverseMap();
            CreateMap<Subscribe, SubscribeUpdateDto>().ReverseMap();
            CreateMap<Subscribe, SubscribeGetDto>().ReverseMap();
        }
    }
}
