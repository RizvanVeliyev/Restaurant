using FluentValidation;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Validators.CategoryDetailValidators;

namespace Restaurant.BLL.Validators.CategoryValidators
{
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleForEach(x => x.CategoryDetails).SetValidator(new CategoryDetailCreateDtoValidator());
        }
    }
}
