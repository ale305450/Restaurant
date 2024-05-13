using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.Order.Validators;
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
        private readonly IMenuItemRepository _menuItemRepository;


        public UpdateOrderCommandHandler(IOrderRepository orderRepository
            , IMapper mapper
            , IMenuItemRepository menuItemRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateOrderDtoValidator(_menuItemRepository);

            var validationResult = await validator.ValidateAsync(request.UpdateOrderDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Order update failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var order = await _orderRepository.Get(request.Id);

            if (request.UpdateOrderDto != null)
            {
                _mapper.Map(request.UpdateOrderDto, order);

                await _orderRepository.Update(order);
            }
            else if (request.ChangeOrderStatusDto != null)
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
