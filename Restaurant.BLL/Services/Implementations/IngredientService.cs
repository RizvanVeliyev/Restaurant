using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurant.BLL.Dtos.IngredientDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        public Task<bool> CreateAsync(IngredientCreateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredientGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
        {
            throw new NotImplementedException();
        }

        public Task<IngredientGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
        {
            throw new NotImplementedException();
        }

        public Task<IngredientCreateDto> GetCreateDtoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IngredientCreateDto> GetCreateDtoAsync(IngredientCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredientGetDto>> GetIngredientsAsync(Languages language = Languages.Azerbaijan)
        {
            throw new NotImplementedException();
        }

        public Task<IngredientUpdateDto> GetUpdatedDtoAsync(IngredientUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IngredientUpdateDto> GetUpdatedDtoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IngredientUpdateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }
    }
}
