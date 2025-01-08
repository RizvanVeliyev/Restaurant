using FluentValidation;
using Restaurant.BLL.Dtos.ProductDtos;
using Restaurant.BLL.Validators.ProductDetailValidators;

namespace Restaurant.BLL.Validators.ProductValidators
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0);

            RuleForEach(x => x.ProductDetails).SetValidator(new ProductDetailUpdateDtoValidator());
        }
    }
}
