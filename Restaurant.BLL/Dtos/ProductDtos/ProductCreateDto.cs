using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Dtos.IngredientDtos;
using Restaurant.BLL.Dtos.ProductDetailDtos;

namespace Restaurant.BLL.Dtos.ProductDtos
{
    public class ProductCreateDto:IDto
    {
        public List<CategoryGetDto>? Categories { get; set; } = [];
        public List<IngredientGetDto>? Ingredients { get; set; } = [];
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public IFormFile MainImage { get; set; } = null!;
        public List<IFormFile> Images { get; set; } = [];
        public List<ProductDetailCreateDto> ProductDetails { get; set; } = [];
    }
}
