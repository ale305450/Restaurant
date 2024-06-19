using FluentValidation;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Order.Validators
{
    public class IOrderDtoValidator : AbstractValidator<IOrderDto>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public IOrderDtoValidator(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;

            RuleFor(o => o.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .LessThan(10).WithMessage("{PropertyName} must not be above {ComparisonValue} itmes")
                .GreaterThan(0).WithMessage("{PropertyName} must not be less than {ComparisonValue} itmes");

            RuleFor(o => o.MenuItemId)
                .MustAsync(async (id, token) =>
                {
                    var menuItemExists = await _menuItemRepository.Exists(id);
                    return !menuItemExists;
                }).WithMessage("");

        }
    }
}
