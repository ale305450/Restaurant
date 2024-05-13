using MediatR;
using Restaurant.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Orders.Requests.Queries
{
    public class GetOrderDetailRequest :IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
