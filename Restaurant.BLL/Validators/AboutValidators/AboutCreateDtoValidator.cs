using FluentValidation;
using Restaurant.BLL.Dtos.AboutDtos;
using Restaurant.BLL.Validators.AboutDetailValidators;

namespace Restaurant.BLL.Validators.AboutValidators
{
    public class AboutCreateDtoValidator : AbstractValidator<AboutCreateDto>
    {
        public AboutCreateDtoValidator()
        {
            RuleForEach(x => x.AboutDetails).SetValidator(new AboutDetailCreateDtoValidator());
        }
    }
}
