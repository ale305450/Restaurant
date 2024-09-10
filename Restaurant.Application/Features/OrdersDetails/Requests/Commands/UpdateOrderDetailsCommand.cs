using MediatR;
using Restaurant.Application.DTOs.OrderDetails;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.OrdersDetails.Requests.Commands
{
    public class UpdateOrderDetailsCommand :IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public UpdateOrderDetailsDto UpdateOrderDetailsDto { get; set; }
    }
}
