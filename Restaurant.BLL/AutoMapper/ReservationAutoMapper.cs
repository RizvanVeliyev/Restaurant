using AutoMapper;
using Restaurant.BLL.Dtos.ReservationDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class ReservationAutoMapper : Profile
    {
        public ReservationAutoMapper()
        {
            CreateMap<Reservation, ReservationCreateDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();


            //CreateMap<Reservation, ReservationUpdateDto>().ReverseMap();

        }
    }
}
