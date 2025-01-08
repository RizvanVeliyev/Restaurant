using FluentValidation;
using Restaurant.BLL.Dtos.BlogDtos;
using Restaurant.BLL.Validators.BlogDetailValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Validators.BlogValidators
{
    public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
    {
        public BlogCreateDtoValidator()
        {
            RuleFor(x => x.Image).NotNull();

            RuleForEach(x => x.BlogDetails).SetValidator(new BlogDetailCreateDtoValidator());
        }
    }
}
