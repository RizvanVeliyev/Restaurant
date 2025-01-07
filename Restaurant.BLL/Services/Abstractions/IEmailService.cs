using Restaurant.BLL.Dtos.EmailDtos;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailSendDto dto);
    }
}
