using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.Order;
using Restaurant.Application.Features.Orders.Requests.Queries;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Orders.Handlers.Queries
{
    public class GetOrderDetailRequestHandler : IRequestHandler<GetOrderDetailRequest, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderRequestWithDetails(request.Id);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
