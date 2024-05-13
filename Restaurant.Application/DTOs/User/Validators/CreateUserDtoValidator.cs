using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.User.Validators
{
    internal class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            Include(new IUserDtoValidator());
        }
    }
}
