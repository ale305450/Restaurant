using MediatR;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.Orders.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Application.Responses;

namespace Restaurant.Application.Features.Orders.Handlers.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, BaseCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var order = await _orderRepository.Get(request.Id);

            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);

            await _orderRepository.Delete(order);


            response.Success = true;
            response.Message = "Order Deleted successfully";
            response.Id = order.Id;

            return response;
        }
    }
}
