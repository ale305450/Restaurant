using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.MenuItem.Validators
{
    public class IMenuItemDtoValidator : AbstractValidator<IMenuItemDto>
    {
        public IMenuItemDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");

            RuleFor(m => m.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(m => m.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .LessThan(10000).WithMessage("{PropertyName} must not be above {ComparisonValue} Real")
                .GreaterThan(500).WithMessage("{PropertyName} must not be less than {ComparisonValue} Real");
        }
    }
}
