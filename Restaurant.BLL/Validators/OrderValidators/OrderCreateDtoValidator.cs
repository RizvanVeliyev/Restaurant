using FluentValidation;
using Restaurant.BLL.Dtos.OrderDtos;

namespace Restaurant.BLL.Validators.OrderValidators
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(64);
        }
    }
}
