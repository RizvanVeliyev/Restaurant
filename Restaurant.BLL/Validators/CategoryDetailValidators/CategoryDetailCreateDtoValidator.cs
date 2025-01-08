using FluentValidation;
using Restaurant.BLL.Dtos.CategoryDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Validators.CategoryDetailValidators
{
    public class CategoryDetailCreateDtoValidator : AbstractValidator<CategoryDetailCreateDto>
    {
        public CategoryDetailCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(32);

        }
    }
}
