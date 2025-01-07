using Restaurant.BLL.Dtos.AboutDtos;
using Restaurant.BLL.Services.Abstractions.Generics;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IAboutService : IModifyService<AboutCreateDto, AboutUpdateDto>, IGetServiceWithLanguage<AboutGetDto>
    {
    }
}
