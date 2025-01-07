﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Dtos.AboutDtos;
using Restaurant.BLL.Extensions;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.DAL.Localizers;
using Restaurant.DAL.Repositories.Abstractions;
using Restaurant.BLL.Exceptions;

namespace Restaurant.BLL.Services.Implementations
{
    public class AboutService : IAboutService
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

        public async Task DeleteAsync(int id)
        {
            var about = await _repository.GetAsync(id);

            if (about is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            _repository.Delete(about);
            await _repository.SaveChangesAsync();

            if (!string.IsNullOrWhiteSpace(about.ImagePath))
                await _cloudinaryService.FileDeleteAsync(about.ImagePath);
        }


        public async Task<List<AboutGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
        {
            _checkLanguageId(ref language);

            var abouts = await _repository.GetAll(_getIncludeFunc(language)).ToListAsync();

            var dtos = _mapper.Map<List<AboutGetDto>>(abouts);

            return dtos;
        }


        public async Task<AboutGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
        {
            _checkLanguageId(ref language);

            var about = await _repository.GetAsync(id, _getIncludeFunc(language));

            if (about is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<AboutGetDto>(about);

            return dto;
        }


        public async Task<AboutUpdateDto> GetUpdatedDtoAsync(int id)
        {
            var about = await _repository.GetAsync(id, x => x.Include(x => x.AboutDetails));

            if (about is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<AboutUpdateDto>(about);

            return dto;
        }

        public async Task<bool> UpdateAsync(AboutUpdateDto dto, ModelStateDictionary ModelState)
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


            

            #endregion

            var existAbout = await _repository.GetAsync(x => x.Id == dto.Id, x => x.Include(x => x.AboutDetails));

            if (existAbout is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));


            existAbout = _mapper.Map(dto, existAbout);

            if (dto.Image is { })
            {
                string newImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);

                if (!string.IsNullOrWhiteSpace(existAbout.ImagePath))
                    await _cloudinaryService.FileDeleteAsync(existAbout.ImagePath);

                existAbout.ImagePath = newImagePath;
            }

            _repository.Update(existAbout);
            await _repository.SaveChangesAsync();

            return true;
        }






        private void _checkLanguageId(ref Languages language)
        {
            foreach (var l in Enum.GetNames(typeof(Languages)))
            {
                if (language.ToString() == l)
                    return;
            }

            language = Languages.Azerbaijan;
        }
        private bool _checkLanguageId(int id)
        {
            foreach (var l in Enum.GetValues(typeof(Languages)))
            {
                if (id == (int)l)
                    return true;
            }

            return false;
        }

        private Func<IQueryable<About>, IIncludableQueryable<About, object>> _getIncludeFunc(Languages language)
        {

            return x => x.Include(x => x.AboutDetails.Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language);
        }
    }
}