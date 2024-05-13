using MediatR;
using Restaurant.Application.DTOs.MenuItem;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.MenuItems.Requests.Commands
{
    public class CreateMenuItemCommand : IRequest<BaseCommandResponse>
    {
        public CreateMenuItemDto CreateMenuItemDto { get; set; }
    }
}
