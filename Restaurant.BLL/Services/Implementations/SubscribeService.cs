using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Dtos.EmailDtos;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.BLL.Exceptions;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.DAL.Localizers;
using Restaurant.DAL.Repositories.Abstractions;

namespace Restaurant.BLL.Services.Implementations
{
    internal class SubscribeService : ISubscribeService
    {
        private readonly ISubscribeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ErrorLocalizer _errorLocalizer;

        public SubscribeService(ISubscribeRepository repository, IMapper mapper, IEmailService emailService, ErrorLocalizer errorLocalizer)
        {
            _repository = repository;
            _mapper = mapper;
            _emailService = emailService;
            _errorLocalizer = errorLocalizer;
        }

        public async Task<bool> CreateAsync(SubscribeCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var isExist = await _repository.IsExistAsync(x => x.Email.ToUpper() == dto.Email.ToUpper());

            if (isExist)
            {
                ModelState.AddModelError("Email", "Bu email artıq mövcuddur");
                return false;
            }

            var subscribe = _mapper.Map<Subscribe>(dto);

            await _repository.CreateAsync(subscribe);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var subscribe = await _repository.GetAsync(id);

            if (subscribe is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            _repository.Delete(subscribe);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<SubscribeGetDto>> GetAllAsync()
        {
            var subscribes = await _repository.GetAll().ToListAsync();

            var dtos = _mapper.Map<List<SubscribeGetDto>>(subscribes);

            return dtos;
        }

        public async Task<SubscribeGetDto> GetAsync(int id)
        {
            var subscribe = await _repository.GetAsync(id);

            if (subscribe is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<SubscribeGetDto>(subscribe);

            return dto;
        }

        public async Task<SubscribeUpdateDto> GetUpdatedDtoAsync(int id)
        {
            var subscribe = await _repository.GetAsync(id);

            if (subscribe is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<SubscribeUpdateDto>(subscribe);

            return dto;
        }

        public async Task<bool> SendEmailToSubscribres(SubscribeEmailDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var subscribes = await _repository.GetAll().ToListAsync();


            foreach (var subscribe in subscribes)
            {
                var emailDto = new EmailSendDto()
                {
                    Body = dto.Body,
                    Subject = dto.Subject,
                    Attachments = dto.Attachments ?? new(),
                    ToEmail = subscribe.Email
                };

                await _emailService.SendEmailAsync(emailDto);
            }

            return true;
        }

        public async Task<bool> UpdateAsync(SubscribeUpdateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var existSubscribe = await _repository.GetAsync(x => x.Id == dto.Id);

            if (existSubscribe is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var isExist = await _repository.IsExistAsync(x => x.Email == dto.Email.ToUpper() && x.Id != dto.Id);

            if (isExist)
            {
                ModelState.AddModelError("Email", "Bu email artıq mövcuddur");
                return false;
            }

            existSubscribe = _mapper.Map(dto, existSubscribe);

            _repository.Update(existSubscribe);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
