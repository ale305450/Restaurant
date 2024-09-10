using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.OrderDetails.Validators
{
    public class IOrderDetailsDtoValidator : AbstractValidator<IOrderDetailsDto>
    {
        public IOrderDetailsDtoValidator()
        {
            RuleFor(o => o.MenuItemId)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(o => o.OrderId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(o => o.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must not be less than {ComparisonValue} Real");

            RuleFor(o => o.Quantity)
               .NotNull();
        }
    }
}
