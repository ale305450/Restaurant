using MediatR;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.OrdersDetails.Requests.Commands;
using Restaurant.Application.Responses;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.OrdersDetails.Handlers.Commands
{
    public class DeleteOrderDetailsCommandHandler : IRequestHandler<DeleteOrderDetailsCommand, BaseCommandResponse>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public DeleteOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var orderDetails = await _orderDetailsRepository.Get(request.Id);

            if (orderDetails == null)
                throw new NotFoundException(nameof(OrderDetails), request.Id);

            await _orderDetailsRepository.Delete(orderDetails);


            response.Success = true;
            response.Message = "Order details Deleted successfully";
            response.Id = orderDetails.Id;

            return response;
        }
    }
}
