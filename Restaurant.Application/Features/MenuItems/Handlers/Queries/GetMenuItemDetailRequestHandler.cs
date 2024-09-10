using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.MenuItem;
using Restaurant.Application.Features.MenuItems.Requests.Queries;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.MenuItems.Handlers.Queries
{
    public class GetMenuItemDetailRequestHandler : IRequestHandler<GetMenuItemDetailRequest, MenuItemDto>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public GetMenuItemDetailRequestHandler(IMenuItemRepository menuItemsRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemsRepository;
            _mapper = mapper;
        }
        public async Task<MenuItemDto> Handle(GetMenuItemDetailRequest request, CancellationToken cancellationToken)
        {
            var menuItem = await _menuItemRepository.GetMenuItemRequestWithDetails(request.Id);
            return _mapper.Map<MenuItemDto>(menuItem);
        }
    }
}
