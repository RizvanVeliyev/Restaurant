using FluentValidation;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Validators.CategoryDetailValidators;

namespace Restaurant.BLL.Validators.CategoryValidators
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleForEach(x => x.CategoryDetails).SetValidator(new CategoryDetailUpdateDtoValidator());
        }
    }
}
