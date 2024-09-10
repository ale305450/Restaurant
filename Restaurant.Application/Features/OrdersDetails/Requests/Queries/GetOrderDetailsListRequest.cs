using MediatR;
using Restaurant.Application.DTOs.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.OrdersDetails.Requests.Queries
{
    public class GetOrderDetailsListRequest : IRequest<List<OrderDetailsDto>>
    {
        public int Id { get; set; }
    }
}
