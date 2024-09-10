using MediatR;
using Restaurant.Application.DTOs.Order;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Orders.Requests.Commands
{
    public class UpdateOrderCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public ChangeOrderStatusDto ChangeOrderStatusDto { get; set; }
    }
}
