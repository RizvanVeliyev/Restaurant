using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Services.Abstractions.Generics;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface ICategoryService : IModifyService<CategoryCreateDto, CategoryUpdateDto>, IGetServiceWithLanguage<CategoryGetDto>
    {
        //Task<List<CategoryRelationDto>> GetAllForProductAsync();
        Task<List<CategoryGetDto>> GetCategoriesAsync(Languages language = Languages.Azerbaijan);
      
        Task<bool> IsExistAsync(int id);
        Task<CategoryCreateDto> GetCreateDtoAsync();
        Task<CategoryCreateDto> GetCreateDtoAsync(CategoryCreateDto dto);
        Task<CategoryUpdateDto> GetUpdatedDtoAsync(CategoryUpdateDto dto);
    }
}
