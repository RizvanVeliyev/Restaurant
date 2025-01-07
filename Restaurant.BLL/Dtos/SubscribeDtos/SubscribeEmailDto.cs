using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.SubscribeDtos
{
    public class SubscribeEmailDto : IDto
    {
        public string Subject { get; set; } = null!;

        public string Body { get; set; } = null!;

        public List<IFormFile>? Attachments { get; set; } = new();
    }
}
