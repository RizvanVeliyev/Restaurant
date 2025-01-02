using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogDetailDtos;

namespace Restaurant.BLL.Dtos.BlogDtos
{
    public class BlogUpdateDto:IDto
    {
        public int Id { get; set; }
        //public List<BlogCategoryGetDto>? BlogCategories { get; set; } = [];
        public int CategoryId { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? Image { get; set; }
        public List<BlogDetailUpdateDto> ProductDetails { get; set; } = [];

    }
}
