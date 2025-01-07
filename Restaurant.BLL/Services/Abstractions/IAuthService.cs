using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurant.BLL.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto, ModelStateDictionary ModelState);
        Task<bool> LoginAsync(LoginDto dto, ModelStateDictionary ModelState);
        Task<bool> LogoutAsync();
        Task<bool> VerifyEmailAsync(VerifyEmailDto dto, ModelStateDictionary ModelState);
        Task<List<UserGetDto>> GetAllUserAsync();
        Task<UserGetDto> GetUserAsync(string id);
        //Task<bool> ChangeUserRoleAsync(UserChangeRoleDto dto);
    }
}
