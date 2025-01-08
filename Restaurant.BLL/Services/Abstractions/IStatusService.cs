using Restaurant.BLL.Dtos.StatusDtos;
using Restaurant.BLL.Services.Abstractions.Generics;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IStatusService : IGetServiceWithLanguage<StatusGetDto>
    {
        Task<StatusGetDto> GetFirstAsync(Languages language = Languages.Azerbaijan);
        Task<StatusGetDto> GetLastAsync(Languages language = Languages.Azerbaijan);
    }
}
