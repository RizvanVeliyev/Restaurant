using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.SubscribeDtos
{
    public class SubscribeCreateDto:IDto
    {
        public string Email { get; set; } = null!;

    }
}
