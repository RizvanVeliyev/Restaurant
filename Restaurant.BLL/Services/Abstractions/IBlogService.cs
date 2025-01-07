using Restaurant.BLL.Dtos.BlogDtos;
using Restaurant.BLL.Dtos.ProductDtos;
using Restaurant.BLL.Services.Abstractions.Generics;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IBlogService : IModifyService<BlogCreateDto, BlogUpdateDto>, IGetServiceWithLanguage<BlogGetDto>
    {
        Task<BlogCreateDto> GetCreatedDtoAsync();
        Task<BlogCreateDto> GetCreatedDtoAsync(BlogCreateDto dto);
        Task<BlogUpdateDto> GetUpdatedDtoAsync(BlogUpdateDto dto);
        Task<bool> IsExistAsync(int id);

    }
}
