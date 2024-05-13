using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.MenuItem.Validators
{
    public class CreateMenuItemDtoValidator : AbstractValidator<CreateMenuItemDto>
    {
        public CreateMenuItemDtoValidator()
        {
            Include(new IMenuItemDtoValidator());
        }
    }
}
