using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.MenuItem.Validators;
using Restaurant.Application.Features.MenuItems.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.MenuItems.Handlers.Commands
{
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, BaseCommandResponse>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public UpdateMenuItemCommandHandler(IMenuItemRepository menuItemsRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemsRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateMenuItemDtoValidator();

            var validationResult = await validator.ValidateAsync(request.UpdateMenuItemDto);


            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "MenuItem update failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var menuItem = await _menuItemRepository.Get(request.UpdateMenuItemDto.Id);

                _mapper.Map(request.UpdateMenuItemDto, menuItem);

                await _menuItemRepository.Update(menuItem);

                response.Success = true;
                response.Message = "MenuItem updated successfully";
                response.Id = menuItem.Id;
            }
            return response;
        }
    }
}
