using FluentValidation;
using Restaurant.BLL.Dtos.BlogCategoryDtos;
using Restaurant.BLL.Validators.BlogBlogCategoryDetailValidators;

namespace Restaurant.BLL.Validators.BlogBlogCategoryValidators
{
    public class BlogCategoryCreateDtoValidator : AbstractValidator<BlogCategoryCreateDto>
    {
        public BlogCategoryCreateDtoValidator()
        {
            RuleForEach(x => x.BlogCategoryDetails).SetValidator(new BlogCategoryDetailCreateDtoValidator());
        }
    }
}
