using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.SubscribeDtos
{
    public class SubscribeGetDto:IDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
    }
}
