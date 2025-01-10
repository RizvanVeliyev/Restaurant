using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    }
}
