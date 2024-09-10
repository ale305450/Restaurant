using AutoMapper;
using MediatR;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.DTOs.OrderDetails;
using Restaurant.Application.Features.OrdersDetails.Requests.Queries;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.OrdersDetails.Handlers.Queries
{
    public class GetOrderDetailsDetailRequestHandler : IRequestHandler<GetOrderDetailsDetailRequest, OrderDetailsDto>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;
        public GetOrderDetailsDetailRequestHandler(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<OrderDetailsDto> Handle(GetOrderDetailsDetailRequest request, CancellationToken cancellationToken)
        {
           var orderDetails = await _orderDetailsRepository.GetOrderDetailsRequestWithDetails(request.Id);
            return _mapper.Map<OrderDetailsDto>(orderDetails);
        }
    }
}
