using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.CommentDtos;
using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class ShopDetailDto : IDto
    {
        public ProductGetDto Product { get; set; } = null!;
        public List<CommentGetDto> Comments { get; set; } = [];
        public bool IsAllowComment { get; set; } = false;
    }
}
