using Restaurant.BLL.Abstractions.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.BLL.Dtos.AppUserDtos
{
    public class LoginDto : IDto
    {
        public string EmailOrUsername { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; } = false;
        public string? ReturnUrl { get; set; }
    }
}
