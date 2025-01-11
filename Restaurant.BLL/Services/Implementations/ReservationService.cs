using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.ReservationDtos;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.DAL.Repositories.Abstractions;

namespace Restaurant.BLL.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(ReservationCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var reservation = _mapper.Map<Reservation>(dto);

            await _repository.CreateAsync(reservation);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<ReservationDto> GetReservationAsync(int id)
        {
            var reservation = await _repository.GetAll()
                .Include(r => r.Products) 
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
                throw new KeyNotFoundException("Reservation not found");

            var reservationDto = _mapper.Map<ReservationDto>(reservation);


            return reservationDto;
        }


        public async Task<ReservationDto?> GetLatestReservationAsync(string name, string phoneNumber)
        {
            var reservation = await _repository.GetAll()
                .Where(r => r.Name == name && r.PhoneNumber == phoneNumber)
                .OrderByDescending(r => r.Date)
                .ThenByDescending(r => r.Id)
                .FirstOrDefaultAsync();

            if (reservation == null)
                return null;

            var reservationDto = _mapper.Map<ReservationDto>(reservation);
            return reservationDto;
        }

    }
}
