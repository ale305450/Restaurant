using MediatR;
using Restaurant.Application.DTOs.Order;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Orders.Requests.Commands
{
    public class CreateOrderCommand : IRequest<BaseCommandResponse>
    {
        public CreateOrderDto CreateOrderDto { get; set; }
    }
}
