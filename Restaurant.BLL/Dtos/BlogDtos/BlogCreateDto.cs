using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogDetailDtos;
using Restaurant.BLL.Dtos.BlogCategoryDtos;
using Restaurant.BLL.Dtos.CategoryDtos;
namespace Restaurant.BLL.Dtos.BlogDtos
{
    public class BlogCreateDto:IDto
    {
        //public List<BlogCategoryGetDto> BlogCategories { get; set; }
        public int BlogCategoryId { get; set; }
        public IFormFile Image { get; set; } = null!;
        public string Author { get; set; } = null!;
        public List<BlogDetailCreateDto> BlogDetails { get; set; } = [];
        public List<BlogCategoryGetDto>? BlogCategories { get; set; } = [];


    }
}
