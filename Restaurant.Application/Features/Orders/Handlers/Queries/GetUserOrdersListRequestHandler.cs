using AutoMapper;
using MediatR;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.DTOs.Order;
using Restaurant.Application.Features.Orders.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Orders.Handlers.Queries
{
    public class GetUserOrdersListRequestHandler : IRequestHandler<GetUserOrdersListRequest, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetUserOrdersListRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetUserOrdersListRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetCurrentUserOrders(request.UserId);
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
