using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.ProductDetailDtos
{
    public class ProductDetailUpdateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int LanguageId { get; set; }
    }
}
