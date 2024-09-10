using MediatR;
using Restaurant.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Orders.Requests.Queries
{
    public class GetUserOrdersListRequest : IRequest<List<OrderDto>>
    {
        public string UserId { get; set; }

    }
}
