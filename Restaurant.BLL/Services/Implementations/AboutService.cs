using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurant.BLL.Dtos.AboutDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.DAL.Repositories.Abstractions;

namespace Restaurant.BLL.Services.Implementations
{
    internal class AboutService : IAboutService
    {
        private readonly IAboutRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMapper _mapper;
        private readonly ErrorLocalizer _errorLocalizer;

        public AboutService(IAboutRepository repository, ICloudinaryService cloudinaryService, IMapper mapper, ErrorLocalizer errorLocalizer)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
            _errorLocalizer = errorLocalizer;
        }

        public async Task<bool> CreateAsync(AboutCreateDto dto, ModelStateDictionary ModelState)
        {
            #region Validations

            if (!ModelState.IsValid)
                return false;

            if (!dto.Image?.ValidateSize(2) ?? false)
            {
                ModelState.AddModelError("Image", "Şəkil ölçüsü 2 mb dan çox ola bilməz.");
                return false;
            }
            if (!dto.Image?.ValidateType() ?? false)
            {
                ModelState.AddModelError("Image", "Yalnız şəkil formatında fayl daxil edə bilərsiniz");
                return false;
            }

            foreach (var detail in dto.AboutDetails)
            {
                var isExistLanguage = _checkLanguageId(detail.LanguageId);

                if (!isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }

                isExistLanguage = dto.AboutDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

                if (isExistLanguage)
                {
                    ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                    return false;
                }
            }


            var isExist = await _repository.IsExistAsync(x => x.OrderNo == dto.OrderNo);

            if (isExist)
            {
                ModelState.AddModelError("OrderNo", "Bu sıra nömrəsi artıq mövcuddur.");
                return false;
            }

            #endregion


            var about = _mapper.Map<About>(dto);

            if (dto.Image is { })
            {
                string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);

                about.ImagePath = imagePath;
            }

            await _repository.CreateAsync(about);
            await _repository.SaveChangesAsync();

            return true;


        }
    }
