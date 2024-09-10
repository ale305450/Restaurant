using AutoMapper;
using MediatR;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.DTOs.OrderDetails.Validators;
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
    public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand, BaseCommandResponse>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;

        public CreateOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository
            , IMapper mapper
            )
        {
            _orderDetailsRepository = orderDetailsRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateOrderDetailsDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CreateOrderDetailsDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Order details creation failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var orderDetails = _mapper.Map<OrderDetails>(request.CreateOrderDetailsDto);

                orderDetails = await _orderDetailsRepository.Add(orderDetails);

                response.Success = true;
                response.Message = "Order details created successfully";
                response.Id = orderDetails.Id;
            }
            return response;
        }
    }
}
