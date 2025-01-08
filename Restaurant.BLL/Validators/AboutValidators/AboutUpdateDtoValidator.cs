using FluentValidation;
using Restaurant.BLL.Dtos.AboutDtos;
using Restaurant.BLL.Validators.AboutDetailValidators;

namespace Restaurant.BLL.Validators.AboutValidators
{
    public class AboutUpdateDtoValidator : AbstractValidator<AboutUpdateDto>
    {
        public AboutUpdateDtoValidator()
        {
            RuleForEach(x => x.AboutDetails).SetValidator(new AboutDetailUpdateDtoValidator());
        }
    }
}
