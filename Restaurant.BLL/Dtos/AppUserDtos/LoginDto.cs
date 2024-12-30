using Restaurant.BLL.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
