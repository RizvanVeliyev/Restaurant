using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.StatusDtos
{
    public class StatusGetDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
