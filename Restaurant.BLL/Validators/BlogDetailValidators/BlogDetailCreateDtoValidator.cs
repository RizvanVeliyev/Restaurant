using FluentValidation;
using Restaurant.BLL.Dtos.BlogDetailDtos;

namespace Restaurant.BLL.Validators.BlogDetailValidators
{
    public class BlogDetailCreateDtoValidator : AbstractValidator<BlogDetailCreateDto>
    {
        public BlogDetailCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(5000).MinimumLength(1);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(128).MinimumLength(2);
        }
    }
}
