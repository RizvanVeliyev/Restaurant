using Restaurant.BLL.Dtos.BlogCategoryDtos;
using Restaurant.BLL.Services.Abstractions.Generics;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IBlogCategoryService : IModifyService<BlogCategoryCreateDto, BlogCategoryUpdateDto>, IGetServiceWithLanguage<BlogCategoryGetDto>
    {
        Task<List<BlogCategoryGetDto>> GetBlogCategoriesAsync(Languages language = Languages.Azerbaijan);
        
        Task<bool> IsExistAsync(int id);
        Task<BlogCategoryCreateDto> GetCreateDtoAsync();
        Task<BlogCategoryCreateDto> GetCreateDtoAsync(BlogCategoryCreateDto dto);
        Task<BlogCategoryUpdateDto> GetUpdatedDtoAsync(BlogCategoryUpdateDto dto);
    }
}
