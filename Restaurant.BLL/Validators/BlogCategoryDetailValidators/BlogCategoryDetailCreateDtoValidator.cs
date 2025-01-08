using FluentValidation;
using Restaurant.BLL.Dtos.BlogCategoryDetailDtos;

namespace Restaurant.BLL.Validators.BlogBlogCategoryDetailValidators
{
    public class BlogCategoryDetailCreateDtoValidator : AbstractValidator<BlogCategoryDetailCreateDto>
    {
        public BlogCategoryDetailCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(32);

        }
    }
}
