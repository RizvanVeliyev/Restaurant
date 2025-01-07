using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Exceptions;
using Restaurant.BLL.Extensions;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.DAL.Localizers;
using Restaurant.DAL.Repositories.Abstractions;

namespace Restaurant.BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
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

        public async Task<List<CategoryGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
        {
            LanguageHelper.CheckLanguageId(ref language);
            var categories = await _repository.GetAll(x => x.Include(x => x.CategoryDetails.
            Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language).
            Include(x => x.Products)).ToListAsync();

            var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

            return dtos;
        }

        public async Task<CategoryGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
        {
            LanguageHelper.CheckLanguageId(ref language);
            var category = await _repository.GetAsync(id, x => x.Include(x => x.CategoryDetails.Where(x => x.LanguageId == (int)language)));

            if (category is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<CategoryGetDto>(category);

            return dto;
        }



        public async Task<List<CategoryGetDto>> GetCategoriesAsync(Languages language = Languages.Azerbaijan)
        {
            var categories = await _repository.GetAll(_getIncludeFunc(Languages.Azerbaijan)).ToListAsync();

            var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

            return dtos;
        }

        public async Task<CategoryCreateDto> GetCreateDtoAsync()
        {
            var categories = await _repository.GetAll(x => x.Include(x => x.CategoryDetails)).ToListAsync();

            var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

            var dto = new CategoryCreateDto() { Categories = dtos, CategoryDetails = [new(), new(), new()] };

            return dto;
        }


        public async Task<CategoryCreateDto> GetCreateDtoAsync(CategoryCreateDto dto)
        {
            var categories = await _repository.GetAll(x => x.Include(x => x.CategoryDetails)).ToListAsync();

            var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

            dto.Categories = dtos;

            return dto;
        }




        public async Task<CategoryUpdateDto> GetUpdatedDtoAsync(CategoryUpdateDto dto)
        {
            var category = await _repository.GetAsync(dto.Id, x => x.Include(x => x.CategoryDetails));

            if (category is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));


            var categories = await _repository.GetAll(x => x.Include(x => x.CategoryDetails)).ToListAsync();

            var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

            dto.Categories = dtos;

            return dto;
        }


        public async Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id)
        {
            var category = await _repository.GetAsync(id, x => x.Include(x => x.CategoryDetails));

            if (category is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<CategoryUpdateDto>(category);

            

            var categories = await _repository.GetAll(x => x.Include(x => x.CategoryDetails)).ToListAsync();

            var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

            dto.Categories = dtos;

            return dto;
        }


        public async Task<bool> IsExistAsync(int id)
        {
            var isExist = await _repository.IsExistAsync(x => x.Id == id);
            return isExist;
        }

        public async Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var existCategory = await _repository.GetAsync(x => x.Id == dto.Id, x => x.Include(x => x.CategoryDetails).Include(x => x.Products));

            if (existCategory is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

           

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

            
            existCategory = _mapper.Map(dto, existCategory);

            _repository.Update(existCategory);
            await _repository.SaveChangesAsync();

            return true;
        }




        private Func<IQueryable<Category>, IIncludableQueryable<Category, object>> _getIncludeFunc(Languages language)
        {
            LanguageHelper.CheckLanguageId(ref language);
            return x => x.Include(x => x.CategoryDetails.Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language);
        }
    }
}
