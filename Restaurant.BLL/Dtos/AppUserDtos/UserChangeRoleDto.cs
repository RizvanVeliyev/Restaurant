using Restaurant.BLL.Abstractions.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.BLL.Dtos.AppUserDtos
{
    public class UserChangeRoleDto : IDto
    {
        [Required(ErrorMessage = "İstifadəçi ID sahəsi boş ola bilməz.")]
        public string UserId { get; set; } = null!;

        [Required(ErrorMessage = "Rol adı sahəsi boş ola bilməz.")]
        public string RoleName { get; set; } = null!;
    }
}
