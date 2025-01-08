using AutoMapper;
using Restaurant.BLL.Dtos.AboutDetailDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class AboutDetailAutoMapper : Profile
    {
        public AboutDetailAutoMapper()
        {
            CreateMap<AboutDetail, AboutDetailCreateDto>().ReverseMap();
            CreateMap<AboutDetail, AboutDetailUpdateDto>().ReverseMap();
        }
    }
}
