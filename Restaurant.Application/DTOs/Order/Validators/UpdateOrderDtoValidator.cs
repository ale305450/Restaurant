using FluentValidation;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Order.Validators
{
    public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public UpdateOrderDtoValidator(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;

            Include(new IOrderDtoValidator(_menuItemRepository));

            RuleFor(o => o.Id).NotNull().WithMessage("{PropertyName} should be present"); ;
        }
    }
}
