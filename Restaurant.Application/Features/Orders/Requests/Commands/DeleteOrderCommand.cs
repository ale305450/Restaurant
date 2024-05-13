using MediatR;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Orders.Requests.Commands
{
    public class DeleteOrderCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
