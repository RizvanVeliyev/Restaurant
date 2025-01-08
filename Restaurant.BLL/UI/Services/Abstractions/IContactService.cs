using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurant.BLL.UI.Dtos;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.UI.Services.Abstractions
{
    public interface IContactService
    {
        Task<ContactDto> GetContactDtoAsync(Languages language = Languages.Azerbaijan);
        Task<bool> SendEmailAsync(ContactDto dto, ModelStateDictionary ModelState);
    }
}
