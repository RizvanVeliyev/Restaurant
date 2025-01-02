using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogDetailDtos;
using Restaurant.BLL.Dtos.BlogCategoryDtos;
namespace Restaurant.BLL.Dtos.BlogDtos
{
    public class BlogCreateDto:IDto
    {
        //public List<BlogCategoryGetDto> BlogCategories { get; set; }
        public int BlogCategoryId { get; set; }
        public IFormFile Image { get; set; } = null!;
        public List<IFormFile> Images { get; set; } = [];
        public List<BlogDetailCreateDto> ProductDetails { get; set; } = [];

    }
}
