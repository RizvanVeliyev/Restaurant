using Restaurant.BLL.Dtos.CartDtos;
using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface ICartService
    {
        Task<bool> AddToBasketAsync(int id, int count = 1);
        Task<bool> DecreaseToBasketAsync(int id);
        Task RemoveToBasketAsync(int id);
        Task<CartGetDto> GetBasketAsync(Languages language = Languages.Azerbaijan);
        Task ClearBasketAsync();
    }
}
