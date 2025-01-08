using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogCategoryDtos;
using Restaurant.BLL.Dtos.BlogDetailDtos;

namespace Restaurant.BLL.Dtos.BlogDtos
{
    public class BlogUpdateDto:IDto
    {
        public int Id { get; set; }
        //public List<BlogCategoryGetDto>? BlogCategories { get; set; } = [];
        public int BlogCategoryId { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? Image { get; set; }
        public List<BlogDetailUpdateDto> BlogDetails { get; set; } = [];
        public List<BlogCategoryGetDto>? BlogCategories { get; set; } = [];


    }
}
