using AutoMapper;
using MediatR;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.DTOs.OrderDetails.Validators;
using Restaurant.Application.Features.OrdersDetails.Requests.Commands;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.OrdersDetails.Handlers.Commands
{
    public class UpdateOrderDetailsCommandHandler : IRequestHandler<UpdateOrderDetailsCommand, BaseCommandResponse>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository
            , IMapper mapper
            )
        {
            _orderDetailsRepository = orderDetailsRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateOrderDetailsDtoValidator();

            var validationResult = await validator.ValidateAsync(request.UpdateOrderDetailsDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Order details update failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var orderDetails = await _orderDetailsRepository.Get(request.Id);

                _mapper.Map(request.UpdateOrderDetailsDto, orderDetails);

                await _orderDetailsRepository.Update(orderDetails);

                response.Success = true;
                response.Message = "Order details updated successfully";
                response.Id = orderDetails.Id;
            }
            return response;
        }
    }
}
