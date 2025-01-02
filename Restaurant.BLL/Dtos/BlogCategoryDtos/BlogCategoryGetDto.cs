using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.BlogCategoryDtos
{
    public class BlogCategoryGetDto:IDto
    {
        public int Id { get; set; }
        //public List<ProductGetDto> Products { get; set; } = [];
    }
}
