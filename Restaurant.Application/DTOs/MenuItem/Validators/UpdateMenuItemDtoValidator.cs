using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.MenuItem.Validators
{
    public class UpdateMenuItemDtoValidator : AbstractValidator<UpdateMenuItemDto>
    {
        public UpdateMenuItemDtoValidator()
        {
            Include(new IMenuItemDtoValidator());

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} should be present");
        }
    }
}
