using AutoMapper;
using MediatR;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.MenuItems.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Application.Responses;

namespace Restaurant.Application.Features.MenuItems.Handlers.Commands
{
    public class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand, BaseCommandResponse>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public DeleteMenuItemCommandHandler(IMenuItemRepository menuItemsRepository)
        {
            _menuItemRepository = menuItemsRepository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var menuItem = await _menuItemRepository.Get(request.Id);

            if (menuItem == null)
                throw new NotFoundException(nameof(MenuItem), request.Id);

            await _menuItemRepository.Delete(menuItem);

            response.Success = true;
            response.Message = "User Deleted successfully";
            response.Id = menuItem.Id;

            return response;
        }
    }
}
