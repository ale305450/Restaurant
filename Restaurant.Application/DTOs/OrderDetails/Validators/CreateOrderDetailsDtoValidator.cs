using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.OrderDetails.Validators
{
    public class CreateOrderDetailsDtoValidator : AbstractValidator<CreateOrderDetailsDto>
    {
        public CreateOrderDetailsDtoValidator()
        {
            Include(new IOrderDetailsDtoValidator());
        }
    }
}
