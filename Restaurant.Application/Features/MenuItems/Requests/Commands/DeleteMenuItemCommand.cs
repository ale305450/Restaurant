using MediatR;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.MenuItems.Requests.Commands
{
    public class DeleteMenuItemCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
