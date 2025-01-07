using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Dtos.ProductDetailDtos;

namespace Restaurant.BLL.Dtos.ProductDtos
{
    public class ProductUpdateDto : IDto
    {
        public int Id { get; set; }
        public List<CategoryGetDto>? Categories { get; set; } = [];
        public int CategoryId { get; set; }

        public string? MainImagePath { get; set; }
        public IFormFile? MainImage { get; set; }
        public List<IFormFile> Images { get; set; } = [];
        public List<string> ImagePaths { get; set; } = [];
        public List<int> ImageIds { get; set; } = [];

        public decimal Price { get; set; }
        public List<ProductDetailUpdateDto> ProductDetails { get; set; } = [];
    }
}
