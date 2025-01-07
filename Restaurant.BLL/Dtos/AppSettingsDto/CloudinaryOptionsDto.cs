using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.AppSettingsDto
{

    public class CloudinaryOptionsDto : IDto
    {
        public string APIKey { get; set; } = null!;
        public string APISecret { get; set; } = null!;
        public string CloudName { get; set; } = null!;

    }
}
