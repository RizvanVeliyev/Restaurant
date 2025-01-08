using AutoMapper;
using Restaurant.BLL.Dtos.AppUserDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class AppUserAutoMapper : Profile
    {
        public AppUserAutoMapper()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, UserGetDto>().ReverseMap();
        }
    }
}
