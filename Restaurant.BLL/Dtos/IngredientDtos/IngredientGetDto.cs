using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.IngredientDtos
{
    public class IngredientGetDto:IDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
