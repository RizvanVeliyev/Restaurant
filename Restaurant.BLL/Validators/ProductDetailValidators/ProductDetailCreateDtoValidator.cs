using FluentValidation;
using Restaurant.BLL.Dtos.ProductDetailDtos;

namespace Restaurant.BLL.Validators.ProductDetailValidators
{
    public class ProductDetailCreateDtoValidator : AbstractValidator<ProductDetailCreateDto>
    {
        public ProductDetailCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(5000).MinimumLength(1);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(128).MinimumLength(2);
        }
    }
}
