using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.User.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            Include(new IUserDtoValidator());

            RuleFor(i => i.Id).NotNull().WithMessage("{PropertyName} should be present");
        }
    }
}
