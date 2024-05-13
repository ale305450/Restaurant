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
    public class GetMenuItemListRequestHandler : IRequestHandler<GetMenuItemListRequest, List<MenuItemDto>>
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public GetMenuItemListRequestHandler(IMenuItemRepository menuItemsRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemsRepository;
            _mapper = mapper;
        }
        public async Task<List<MenuItemDto>> Handle(GetMenuItemListRequest request, CancellationToken cancellationToken)
        {
            var menuItems = await _menuItemRepository.GetAll();
            return _mapper.Map<List<MenuItemDto>>(menuItems);
        }
    }
}
