using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.AboutDetailDtos;

namespace Restaurant.BLL.Dtos.AboutDtos
{
    public class AboutUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; } = null!;
        public IFormFile? Image { get; set; } = null!;
        public List<AboutDetailUpdateDto> AboutDetails { get; set; } = [];
    }
}
