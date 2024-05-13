using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.User.Validators
{
    public class IUserDtoValidator :AbstractValidator<IUserDto>
    {
        public IUserDtoValidator()
        {
            RuleFor(u => u.Name)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull()
              .MaximumLength(30).WithMessage("{PropertyName} must be less than {ComparisonValue}");

            RuleFor(u => u.Email).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must be less than {ComparisonValue}")
                .MinimumLength(10).WithMessage("{PropertyName} must be longer than {ComparisonValue}")
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must be less than {ComparisonValue}")
                .MinimumLength(6).WithMessage("{PropertyName} must be longer than {ComparisonValue}");
        }
    }
}
