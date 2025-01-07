using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.EmailDtos
{
    public class MailKitConfigurationDto : IDto
    {
        public string Mail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Host { get; set; } = null!;
        public string Port { get; set; } = null!;
    }
}
