using AutoMapper;
using MediatR;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.DTOs.OrderDetails;
using Restaurant.Application.Features.OrdersDetails.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.OrdersDetails.Handlers.Queries
{
    internal class GetOrderDetailsListRequestHandler : IRequestHandler<GetOrderDetailsListRequest, List<OrderDetailsDto>>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;
        public GetOrderDetailsListRequestHandler(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<List<OrderDetailsDto>> Handle(GetOrderDetailsListRequest request, CancellationToken cancellationToken)
        {
            var ordersDetails = await _orderDetailsRepository.GetOrdersDetailsRequestWithDetails(request.Id);
            return _mapper.Map<List<OrderDetailsDto>>(ordersDetails);
        }
    }
}
