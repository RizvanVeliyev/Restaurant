﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurant.BLL.Dtos.ReservationDtos;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IReservationService
    {
        Task<bool> CreateAsync(ReservationCreateDto dto, ModelStateDictionary ModelState);
        Task<ReservationDto> GetReservationAsync(int id);
        Task<ReservationDto?> GetLatestReservationAsync(string name, string phoneNumber);


    }
}
