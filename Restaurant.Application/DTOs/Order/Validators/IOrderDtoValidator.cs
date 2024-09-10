using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.Order.Validators
{
    public class IOrderDtoValidator : AbstractValidator<IOrderDto>
    {
        public IOrderDtoValidator()
        {
            RuleFor(o => o.UserId)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
        }
    }
}
