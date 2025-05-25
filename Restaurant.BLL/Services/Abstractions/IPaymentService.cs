using Restaurant.BLL.Dtos;

namespace Restaurant.BLL.Services.Abstractions;

public interface IPaymentService
{
    Task<PaymentResponseDto> CreateAsync(PaymentCreateDto dto);
    Task<bool> CheckPaymentAsync(PaymentCheckDto dto);
}
