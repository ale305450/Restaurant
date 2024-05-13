using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.MenuItem.Validators;
using Restaurant.Application.Features.MenuItems.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.MenuItems.Handlers.Commands
{
    public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, BaseCommandResponse>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public CreateMenuItemCommandHandler(IMenuItemRepository menuItemsRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemsRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateMenuItemDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CreateMenuItemDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "MenuItem creation failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var menuItem = _mapper.Map<MenuItem>(request.CreateMenuItemDto);

            menuItem = await _menuItemRepository.Add(menuItem);

            response.Success = true;
            response.Message = "MenuItem created successfully";
            response.Id = menuItem.Id;

            return response;
        }
    }
}
