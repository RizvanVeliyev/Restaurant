using FluentValidation;
using Restaurant.BLL.Dtos.BlogDtos;
using Restaurant.BLL.Validators.BlogDetailValidators;

namespace Restaurant.BLL.Validators.BlogValidators
{
    public class BlogUpdateDtoValidator : AbstractValidator<BlogUpdateDto>
    {
        public BlogUpdateDtoValidator()
        {

            RuleForEach(x => x.BlogDetails).SetValidator(new BlogDetailUpdateDtoValidator());
        }
    }
}
