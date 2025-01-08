using AutoMapper;
using Restaurant.BLL.Dtos.StatusDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class StatusAutoMapper : Profile
    {
        public StatusAutoMapper()
        {
            CreateMap<Status, StatusGetDto>()
                    .ForMember(x => x.Name, x => x.MapFrom(x => x.StatusDetails.FirstOrDefault() != null ? x.StatusDetails.FirstOrDefault()!.Name : string.Empty));
        }
    }
}
