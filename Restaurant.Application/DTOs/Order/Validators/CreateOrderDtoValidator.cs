using FluentValidation;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Order.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public CreateOrderDtoValidator(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;

            Include(new IOrderDtoValidator(_menuItemRepository));
        }

    }
}
