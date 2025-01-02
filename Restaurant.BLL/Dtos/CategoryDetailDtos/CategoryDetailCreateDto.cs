using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.CategoryDetailDtos
{
    public class CategoryDetailCreateDto:IDto
    {
        public string Name { get; set; } = null!;
        public int LanguageId { get; set; }
    }
}
