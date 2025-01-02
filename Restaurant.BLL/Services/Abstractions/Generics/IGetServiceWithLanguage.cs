using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Abstractions.Generics
{
    public interface IGetServiceWithLanguage<TGetDto>
    where TGetDto : IDto
    {
        Task<TGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan);
        Task<List<TGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan);
    }
}
