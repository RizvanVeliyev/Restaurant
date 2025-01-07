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
        Task<bool> AddToCartAsync(int id, int count = 1);
        Task<bool> DecreaseToCartAsync(int id);
        Task RemoveToCartAsync(int id);
        Task<CartGetDto> GetCartAsync(Languages language = Languages.Azerbaijan);
        Task ClearCartAsync();
    }
}
