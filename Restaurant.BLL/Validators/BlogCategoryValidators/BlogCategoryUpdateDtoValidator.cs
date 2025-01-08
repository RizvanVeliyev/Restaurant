using FluentValidation;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Validators.BlogCategoryDetailValidators;

namespace Restaurant.BLL.Validators.BlogCategoryValidators
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleForEach(x => x.CategoryDetails).SetValidator(new CategoryDetailUpdateDtoValidator());
        }
    }

}
