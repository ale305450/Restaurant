using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.Review.Validators
{
    public class IReviewDtoValidator : AbstractValidator<IReviewDto>
    {
        public IReviewDtoValidator()
        {
            RuleFor(b => b.MenuItemId)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(b => b.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(b => b.Rating)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
