﻿using FluentValidation;
using Restaurant.BLL.Dtos.CommentDtos;

namespace Restaurant.BLL.Validators.CommentValidators
{
    public class CommentUpdateDtoValidator : AbstractValidator<CommentUpdateDto>
    {
        public CommentUpdateDtoValidator()
        {
            RuleFor(x => x.Text).NotEmpty().MaximumLength(512);
            RuleFor(x => x.Rating).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
        }
    }
}
