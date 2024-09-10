using AutoMapper;
using MediatR;
using Restaurant.Application.Features.Orders.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Orders.Handlers.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, BaseCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository
            , IMapper mapper
            , IMenuItemRepository menuItemRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var order = await _orderRepository.Get(request.Id);
            if (request.ChangeOrderStatusDto != null)
            {
                await _orderRepository.ChangeOrderStatus(order, request.ChangeOrderStatusDto.Status);
            }

            response.Success = true;
            response.Message = "Order updated successfully";
            response.Id = order.Id;

            return response;
        }
    }
}
