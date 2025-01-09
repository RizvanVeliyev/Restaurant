using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Restaurant.BLL.Dtos.BlogCategoryDtos;
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
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ErrorLocalizer _errorLocalizer;

        public BlogCategoryService(IBlogCategoryRepository repository, IMapper mapper, ICloudinaryService cloudinaryService, ErrorLocalizer errorLocalizer)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _errorLocalizer = errorLocalizer;
        }

        public async Task<bool> CreateAsync(BlogCategoryCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            foreach (var detail in dto.BlogCategoryDetails)
            {
                var isExistLanguage = LanguageHelper.CheckLanguageId(detail.LanguageId);

                if (!isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }

                isExistLanguage = dto.BlogCategoryDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

                if (isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }
            }

            var BlogCategory = _mapper.Map<BlogCategory>(dto);


            await _repository.CreateAsync(BlogCategory);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var BlogCategory = await _repository.GetAsync(id, x => x.Include(x => x.Blogs));

            if (BlogCategory is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));



            if (BlogCategory.Blogs.Count > 0)
                throw new InvalidInputException(_errorLocalizer.GetValue(nameof(InvalidInputException)));


            _repository.Delete(BlogCategory);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<BlogCategoryGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
        {
            LanguageHelper.CheckLanguageId(ref language);

            var blogCategories = await _repository.GetAll(x => x.Include(x => x.BlogCategoryDetails.
            Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language).
            Include(x => x.Blogs)).ToListAsync();

            var dtos = _mapper.Map<List<BlogCategoryGetDto>>(blogCategories);

            return dtos;
        }

        public async Task<BlogCategoryGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
        {
            LanguageHelper.CheckLanguageId(ref language);
            var BlogCategory = await _repository.GetAsync(id, x => x.Include(x => x.BlogCategoryDetails.Where(x => x.LanguageId == (int)language)));

            if (BlogCategory is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<BlogCategoryGetDto>(BlogCategory);

            return dto;
        }

       

        public async Task<List<BlogCategoryGetDto>> GetBlogCategoriesAsync(Languages language = Languages.Azerbaijan)
        {
            var blogCategories = await _repository.GetAll(_getIncludeFunc(Languages.Azerbaijan)).ToListAsync();

            var dtos = _mapper.Map<List<BlogCategoryGetDto>>(blogCategories);

            return dtos;
        }

        public async Task<BlogCategoryCreateDto> GetCreateDtoAsync()
        {
            var blogCategories = await _repository.GetAll(x => x.Include(x => x.BlogCategoryDetails)).ToListAsync();

            var dtos = _mapper.Map<List<BlogCategoryGetDto>>(blogCategories);

            var dto = new BlogCategoryCreateDto() { BlogCategories = dtos, BlogCategoryDetails = [new(), new(), new()] };

            return dto;
        }


        public async Task<BlogCategoryCreateDto> GetCreateDtoAsync(BlogCategoryCreateDto dto)
        {
            var blogCategories = await _repository.GetAll(x => x.Include(x => x.BlogCategoryDetails)).ToListAsync();

            var dtos = _mapper.Map<List<BlogCategoryGetDto>>(blogCategories);

            dto.BlogCategories = dtos;

            return dto;
        }




        public async Task<BlogCategoryUpdateDto> GetUpdatedDtoAsync(BlogCategoryUpdateDto dto)
        {
            var BlogCategory = await _repository.GetAsync(dto.Id, x => x.Include(x => x.BlogCategoryDetails));

            if (BlogCategory is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));


            var blogCategories = await _repository.GetAll(x => x.Include(x => x.BlogCategoryDetails)).ToListAsync();

            var dtos = _mapper.Map<List<BlogCategoryGetDto>>(blogCategories);

            dto.BlogCategories = dtos;

            return dto;
        }


        public async Task<BlogCategoryUpdateDto> GetUpdatedDtoAsync(int id)
        {
            var BlogCategory = await _repository.GetAsync(id, x => x.Include(x => x.BlogCategoryDetails));

            if (BlogCategory is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<BlogCategoryUpdateDto>(BlogCategory);



            var blogCategories = await _repository.GetAll(x => x.Include(x => x.BlogCategoryDetails)).ToListAsync();

            var dtos = _mapper.Map<List<BlogCategoryGetDto>>(blogCategories);

            dto.BlogCategories = dtos;

            return dto;
        }


        public async Task<bool> IsExistAsync(int id)
        {
            var isExist = await _repository.IsExistAsync(x => x.Id == id);
            return isExist;
        }

        public async Task<bool> UpdateAsync(BlogCategoryUpdateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var existBlogCategory = await _repository.GetAsync(x => x.Id == dto.Id, x => x.Include(x => x.BlogCategoryDetails).Include(x => x.Blogs));

            if (existBlogCategory is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));



            foreach (var detail in dto.BlogCategoryDetails)
            {
                var isExistLanguage = LanguageHelper.CheckLanguageId(detail.LanguageId);

                if (!isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }

                isExistLanguage = dto.BlogCategoryDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

                if (isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }
            }


            existBlogCategory = _mapper.Map(dto, existBlogCategory);

            _repository.Update(existBlogCategory);
            await _repository.SaveChangesAsync();

            return true;
        }




        private Func<IQueryable<BlogCategory>, IIncludableQueryable<BlogCategory, object>> _getIncludeFunc(Languages language)
        {
            LanguageHelper.CheckLanguageId(ref language);
            return x => x.Include(x => x.BlogCategoryDetails.Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language);
        }
    }
}
