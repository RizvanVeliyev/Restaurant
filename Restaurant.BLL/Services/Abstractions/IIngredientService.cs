using Restaurant.BLL.Dtos.IngredientDtos;
using Restaurant.BLL.Services.Abstractions.Generics;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IIngredientService : IModifyService<IngredientCreateDto, IngredientUpdateDto>, IGetServiceWithLanguage<IngredientGetDto>
    {
        //Task<List<IngredientRelationDto>> GetAllForProductAsync();
        Task<List<IngredientGetDto>> GetIngredientsAsync(Languages language = Languages.Azerbaijan);

        Task<bool> IsExistAsync(int id);
        Task<IngredientCreateDto> GetCreateDtoAsync();
        Task<IngredientCreateDto> GetCreateDtoAsync(IngredientCreateDto dto);
        Task<IngredientUpdateDto> GetUpdatedDtoAsync(IngredientUpdateDto dto);
    }
}
