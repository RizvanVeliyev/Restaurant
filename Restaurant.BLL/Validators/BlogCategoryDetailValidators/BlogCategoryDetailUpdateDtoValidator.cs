using FluentValidation;
using Restaurant.BLL.Dtos.CategoryDetailDtos;

namespace Restaurant.BLL.Validators.BlogCategoryDetailValidators
{
    public class CategoryDetailUpdateDtoValidator : AbstractValidator<CategoryDetailUpdateDto>
    {
        public CategoryDetailUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(32);
        }
    }
}
