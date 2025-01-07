using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Exceptions;
using Restaurant.BLL.Extensions;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.DAL.Localizers;
using Restaurant.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services.Implementations
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ErrorLocalizer _errorLocalizer;

        public CategoryService(ICategoryRepository repository, IMapper mapper, ICloudinaryService cloudinaryService, ErrorLocalizer errorLocalizer)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _errorLocalizer = errorLocalizer;
        }

        public async Task<bool> CreateAsync(CategoryCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            foreach (var detail in dto.CategoryDetails)
            {
                var isExistLanguage = LanguageHelper.CheckLanguageId(detail.LanguageId);

                if (!isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }

                isExistLanguage = dto.CategoryDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

                if (isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }
            }

            var category = _mapper.Map<Category>(dto);
            
            
            await _repository.CreateAsync(category);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repository.GetAsync(id, x => x.Include(x => x.Products));

            if (category is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            

            if (category.Products.Count > 0)
                throw new InvalidInputException(_errorLocalizer.GetValue(nameof(InvalidInputException)));


            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        public Task<List<CategoryGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryGetDto>> GetCategoriesAsync(Languages language = Languages.Azerbaijan)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryCreateDto> GetCreateDtoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryCreateDto> GetCreateDtoAsync(CategoryCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryUpdateDto> GetUpdatedDtoAsync(CategoryUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }
    }
}
