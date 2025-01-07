using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.BLL.Services.Abstractions.Generics;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface ISubscribeService : IModifyService<SubscribeCreateDto, SubscribeUpdateDto>, IGetService<SubscribeGetDto>
    {
        Task<bool> SendEmailToSubscribres(SubscribeEmailDto dto, ModelStateDictionary ModelState);
    }
}
