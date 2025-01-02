using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.CategoryDetailDtos
{
    public class CategoryDetailUpdateDto:IDto
    {
        public string Name { get; set; } = null!;
        public int LanguageId { get; set; }
    }
}
