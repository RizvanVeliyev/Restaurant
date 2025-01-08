using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Dtos.BlogDtos;
using Restaurant.BLL.Exceptions;
using Restaurant.BLL.Extensions;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.DAL.Localizers;
using Restaurant.DAL.Repositories.Abstractions;

namespace Restaurant.BLL.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly ErrorLocalizer _errorLocalizer;

        public BlogService(IBlogRepository repository, IMapper mapper, ICloudinaryService cloudinaryService, IBlogCategoryService blogCategoryService, ErrorLocalizer errorLocalizer)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _blogCategoryService = blogCategoryService;
            _errorLocalizer = errorLocalizer;
        }

        public async Task<bool> CreateAsync(BlogCreateDto dto, ModelStateDictionary ModelState)
        {

            #region Validations
            if (!ModelState.IsValid)
                return false;

            var isExistBlogCategory = await _blogCategoryService.IsExistAsync(dto.BlogCategoryId);

            if (!isExistBlogCategory)
            {
                ModelState.AddModelError("BlogCategoryId", "Belə Kateqoriya mövcud deyil zəhmət olmasa yenidən daxil edin");
                return false;
            }


            foreach (var detail in dto.BlogDetails)
            {
                var isExistLanguage = LanguageHelper.CheckLanguageId(detail.LanguageId);

                if (!isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }

                isExistLanguage = dto.BlogDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

                if (isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }
            }



            if (!dto.Image.ValidateType())
            {
                ModelState.AddModelError("MainImage", "Yalnız şəkil formatında dəyər daxil edə bilərsiniz");
                return false;
            }

            if (!dto.Image.ValidateSize(2))
            {
                ModelState.AddModelError("MainImage", "Şəkilin ölçüsü 2 mb dan artıq ola bilməz");
                return false;
            }

           

            #endregion

            var blog = _mapper.Map<Blog>(dto);

            string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image); 
            blog.ImageUrl = imagePath;

            

            await _repository.CreateAsync(blog);
            await _repository.SaveChangesAsync();

            return true;
        }



        public async Task DeleteAsync(int id)
        {
            var blog = await _repository.GetAsync(id);

            if (blog is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            _repository.Delete(blog);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<BlogGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
        {
            LanguageHelper.CheckLanguageId(ref language);
            var blogs = await _repository.GetAll(_getIncludeFunc(language)).ToListAsync();


            var dtos = _mapper.Map<List<BlogGetDto>>(blogs);

            return dtos;
        }

        public async Task<BlogGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
        {
            var blog = await _repository.GetAsync(id, _getIncludeFunc(language));

            if (blog is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<BlogGetDto>(blog);

            return dto;
        }

        public async Task<BlogCreateDto> GetCreatedDtoAsync()
        {
            var blogCategories = await _blogCategoryService.GetBlogCategoriesAsync();
            //var ingredients

            BlogCreateDto dto = new()
            {
                BlogCategories = blogCategories,
                BlogDetails = [new(), new(), new()],
            };

            return dto;
        }
        public async Task<BlogCreateDto> GetCreatedDtoAsync(BlogCreateDto dto)
        {
            var blogCategories = await _blogCategoryService.GetBlogCategoriesAsync();

            dto.BlogCategories = blogCategories;


            return dto;
        }

        public async Task<BlogUpdateDto> GetUpdatedDtoAsync(int id)
        {
            var blog = await _repository.GetAsync(id, _getIncludeFunc());

            if (blog is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<BlogUpdateDto>(blog);

            var blogCategories = await _blogCategoryService.GetBlogCategoriesAsync();

            dto.BlogCategories = blogCategories;

            return dto;
        }

        public async Task<BlogUpdateDto> GetUpdatedDtoAsync(BlogUpdateDto dto)
        {
            var blogCategories = await _blogCategoryService.GetBlogCategoriesAsync();

            dto.BlogCategories = blogCategories;

            return dto;
        }



        public async Task<bool> IsExistAsync(int id)
        {
            return await _repository.IsExistAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(BlogUpdateDto dto, ModelStateDictionary ModelState)
        {

            if (!ModelState.IsValid)
                return false;

            var existBlog = await _repository.GetAsync(dto.Id, _getIncludeFunc());

            if (existBlog is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var isExistBlogCategory = await _blogCategoryService.IsExistAsync(dto.BlogCategoryId);

            if (!isExistBlogCategory)
            {
                ModelState.AddModelError("BlogCategoryId", "Belə Kateqoriya mövcud deyil zəhmət olmasa yenidən daxil edin");
                return false;
            }



            foreach (var detail in dto.BlogDetails)
            {
                var isExistLanguage = LanguageHelper.CheckLanguageId(detail.LanguageId);

                if (!isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }

                isExistLanguage = dto.BlogDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

                if (isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }
            }




            if (!dto.Image?.ValidateType() ?? false)
            {
                ModelState.AddModelError("MainImage", "Yalnız şəkil formatında dəyər daxil edə bilərsiniz");
                return false;
            }

            if (!dto.Image?.ValidateSize(2) ?? false)
            {
                ModelState.AddModelError("MainImage", "Şəkilin ölçüsü 2 mb dan artıq ola bilməz");
                return false;
            }



            existBlog = _mapper.Map(dto, existBlog);

            if (dto.Image is { })
            {
                string newImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);

                existBlog.ImageUrl = newImagePath;
            }

            _repository.Update(existBlog);
            await _repository.SaveChangesAsync();

            return true;
        }







        private Func<IQueryable<Blog>, IIncludableQueryable<Blog, object>> _getIncludeFunc(Languages language)
        {
            LanguageHelper.CheckLanguageId(ref language);
            return x => x.Include(x => x.BlogDetails.Where(x => x.LanguageId == (int)language)).Include(x => x.BlogCategory.BlogCategoryDetails.Where(x => x.LanguageId == (int)language));
        }
        private Func<IQueryable<Blog>, IIncludableQueryable<Blog, object>> _getIncludeFunc()
        {
            return x => x.Include(x => x.BlogDetails).Include(x => x.BlogCategory);
        }
    }
}
