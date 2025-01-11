using AutoMapper;
using Restaurant.BLL.Dtos.ReservationDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class ReservationAutoMapper : Profile
    {
        public ReservationAutoMapper()
        {
            //CreateMap<Reservation, ReservationCreateDto>().ReverseMap();
            //CreateMap<Reservation, ReservationDto>().ReverseMap();

            //CreateMap<ReservationCreateDto, Reservation>()
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();

            CreateMap<ReservationCreateDto, Reservation>().ReverseMap();


            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.ReservationNumber, opt => opt.MapFrom(src => src.Id.ToString())).ReverseMap();


        }
    }
}
