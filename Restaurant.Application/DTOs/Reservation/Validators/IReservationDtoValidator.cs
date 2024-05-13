using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Reservation.Validators
{
    public class IReservationDtoValidator : AbstractValidator<IReservationDto>
    {
        public IReservationDtoValidator()
        {
            RuleFor(r => r.Time)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(r => r.Date)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(r => r.NumGuests)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .LessThan(6).WithMessage("{PropertyName} must not be above {ComparisonValue} Real")
                .GreaterThan(0).WithMessage("{PropertyName} must not be less than {ComparisonValue} Real");
        }
    }
}
