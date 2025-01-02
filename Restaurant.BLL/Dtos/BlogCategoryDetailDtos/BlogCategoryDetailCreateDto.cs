using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.BlogCategoryDetailDtos
{
    public class BlogCategoryDetailCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public int LanguageId { get; set; }
    }
}
