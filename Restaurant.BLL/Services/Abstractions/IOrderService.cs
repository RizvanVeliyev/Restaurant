using Restaurant.BLL.Dtos.OrderDtos;
using Restaurant.BLL.Services.Abstractions.Generics;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IOrderService : IModifyService<OrderCreateDto, OrderUpdateDto>, IGetServiceWithLanguage<OrderGetDto>
    {
        Task<List<OrderGetDto>> GetUserOrdersAsync(Languages language = Languages.Azerbaijan);
        Task<OrderGetDto> GetUserOrderAsync(int id, Languages language = Languages.Azerbaijan);
        Task<OrderCreateDto> GetUserUnSubmitOrderAsync(Languages language = Languages.Azerbaijan);
        Task CancelOrderAsync(int id);
        Task RepairOrderAsync(int id);
        Task NextOrderStatusAsync(int id);
        Task PrevOrderStatusAsync(int id);
    }
}
