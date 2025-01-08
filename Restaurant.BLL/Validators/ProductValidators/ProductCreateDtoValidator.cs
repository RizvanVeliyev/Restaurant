using FluentValidation;
using Restaurant.BLL.Dtos.ProductDtos;
using Restaurant.BLL.Validators.ProductDetailValidators;

namespace Restaurant.BLL.Validators.ProductValidators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.MainImage).NotNull();
            RuleFor(x => x.Price).GreaterThan(0);

            RuleForEach(x => x.Images).NotNull().NotEmpty();
            RuleForEach(x => x.ProductDetails).SetValidator(new ProductDetailCreateDtoValidator());
        }
    }
}
