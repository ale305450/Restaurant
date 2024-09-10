using MediatR;
using Restaurant.Application.DTOs.MenuItem;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.MenuItems.Requests.Commands
{
    public class UpdateMenuItemCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public UpdateMenuItemDto UpdateMenuItemDto { get; set; }
    }
}
