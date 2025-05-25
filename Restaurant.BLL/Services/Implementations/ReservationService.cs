using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.ReservationDtos;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Dtos;
using Restaurant.Core.Entities;
using Restaurant.DAL.Repositories.Abstractions;

namespace Restaurant.BLL.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public ReservationService(IReservationRepository repository, IMapper mapper, IEmailService emailService)
        {
            _repository = repository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<bool> CreateAsync(ReservationCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var reservation = _mapper.Map<Reservation>(dto);
            reservation.ReservationNumber = GenerateReservationNumber();


            await _repository.CreateAsync(reservation);
            await _repository.SaveChangesAsync();

            return true;
        }


        private string GenerateReservationNumber()
        {
            // Example: Generate a unique reservation number (could also use a sequential number or GUID)
            return Guid.NewGuid().ToString("N").Substring(0, 8); // This gives a random 8-character string
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




        public async Task<bool> SendEmailAsync(ReservationCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            string emailBody = _getTemplateContent(dto);

            await _emailService.SendEmailAsync(new() { Body = emailBody, ToEmail = "info@Restaurant.az", Subject = "Reservation Info" });

            return true;

        }



        private string _getTemplateContent(ReservationCreateDto dto)
        {

            string result = @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>FAQ Email</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            color: #333;
        }

        .email-container {
            max-width: 600px;
            margin: 20px auto;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        .email-header {
            text-align: center;
            background-color: #00204a;
            color: white;
            padding: 10px;
            border-radius: 8px 8px 0 0;
        }

            .email-header h1 {
                margin: 0;
            }

        .faq-section {
            margin-top: 20px;
        }

        .faq-item {
            margin-bottom: 15px;
        }

            .faq-item h2 {
                font-size: 18px;
                margin-bottom: 5px;
                color: #00204a;
            }

            .faq-item p {
                font-size: 16px;
                margin: 0;
            }

        .footer {
            text-align: center;
            margin-top: 20px;
            padding-top: 10px;
            border-top: 1px solid #ddd;
            font-size: 14px;
            color: #666;
        }

            .footer a {
                color: #00204a;
                text-decoration: none;
            }

                .footer a:hover {
                    text-decoration: underline;
                }
    </style>
</head>
<body>
    <div class=""email-container"">
        <div class=""email-header"">
            <h1>İstifadəçi sorğusu</h1>
        </div>
        <div class=""faq-section"">
            <div class=""faq-item"">
                <h2>Name</h2>
                <p>[REPLACE_NAME]</p>
            </div>
            <div class=""faq-item"">
                <h2>Phone Number</h2>
                <p>[REPLACE_PhoneNumber]</p>
            </div>
            <div class=""faq-item"">
                <h2>Time</h2>
                <p>[REPLACE_Time]</p>
            </div>
            <div class=""faq-item"">
                <h2>Date</h2>
                <p>[REPLACE_Date]</p>
            </div>
       

        </div>

    </div>
</body>
</html>
";

            result = result.Replace("[REPLACE_NAME]", dto.Name);
            result = result.Replace("[REPLACE_PhoneNumber]", dto.PhoneNumber);
            result = result.Replace("[REPLACE_Time]", dto.Time);
            result = result.Replace("[REPLACE_Date]", dto.Date.ToString("yyyy-MM-dd"));



            return result;
        }

    }
}
