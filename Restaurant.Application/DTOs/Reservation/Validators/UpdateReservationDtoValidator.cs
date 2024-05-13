using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Reservation.Validators
{
    public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
    {
        public UpdateReservationDtoValidator()
        {
            Include(new IReservationDtoValidator());

            RuleFor(i => i.Id).NotNull().WithMessage("{PropertyName} should be present");
        }
    }
}
