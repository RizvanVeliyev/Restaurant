using Restaurant.BLL.UI.Dtos;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.UI.Services.Abstractions
{
    public interface IHomeService
    {
        Task<HomeDto> GetHomeDtoAsync(Languages language = Languages.Azerbaijan, int? categoryId = null);
    }
}
