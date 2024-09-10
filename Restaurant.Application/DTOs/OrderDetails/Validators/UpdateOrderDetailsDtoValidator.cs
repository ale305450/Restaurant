using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.OrderDetails.Validators
{
    public class UpdateOrderDetailsDtoValidator : AbstractValidator<UpdateOrderDetailsDto>
    {
        public UpdateOrderDetailsDtoValidator()
        {
            Include(new IOrderDetailsDtoValidator());
            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} should be present");
        }
    }
}
