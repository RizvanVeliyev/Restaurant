using FluentValidation;
using Restaurant.BLL.Dtos.AppUserDtos;

namespace Restaurant.BLL.Validators.AppUserValidators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.EmailOrUsername).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(128);
        }
    }
}
