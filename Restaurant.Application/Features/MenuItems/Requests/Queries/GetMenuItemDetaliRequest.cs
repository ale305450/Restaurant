using MediatR;
using Restaurant.Application.DTOs.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.MenuItems.Requests.Queries
{
    public class GetMenuItemDetaliRequest : IRequest<MenuItemDto>
    {
        public int Id { get; set; }
    }
}
