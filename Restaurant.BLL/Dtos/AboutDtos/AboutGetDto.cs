using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.AboutDtos
{
    public class AboutGetDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
    }
}
