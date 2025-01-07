using Restaurant.BLL.Dtos.ProductDtos;
using Restaurant.BLL.Services.Abstractions.Generics;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IProductService : IModifyService<ProductCreateDto, ProductUpdateDto>, IGetServiceWithLanguage<ProductGetDto>
    {
        Task<ProductCreateDto> GetCreatedDtoAsync();
        Task<ProductCreateDto> GetCreatedDtoAsync(ProductCreateDto dto);
        Task<ProductUpdateDto> GetUpdatedDtoAsync(ProductUpdateDto dto);
        //Task<PaginateDto<ProductGetDto>> GetAllWithPageAsync(Languages language = Languages.Azerbaijan, int page = 1);
        Task IncreaseSalesCountAsync(int productSizeId, int count = 1);
        Task DecreaseSalesCountAsync(int productSizeId, int count = 1);
        Task<bool> IsExistAsync(int id);

    }
}
