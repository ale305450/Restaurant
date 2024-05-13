using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.Order.Validators;
using Restaurant.Application.Features.Orders.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Orders.Handlers.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IMenuItemRepository _menuItemRepository;


        public CreateOrderCommandHandler(IOrderRepository orderRepository
            , IMapper mapper
            , IMenuItemRepository menuItemRepository
            )
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateOrderDtoValidator(_menuItemRepository);

            var validationResult = await validator.ValidateAsync(request.CreateOrderDto);

            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Order creation failed";
                response.Errors = validationResult.Errors.Select(e =>e.ErrorMessage).ToList();
            }

            var order = _mapper.Map<Order>(request.CreateOrderDto);

            order = await _orderRepository.Add(order);

            response.Success = true;
            response.Message = "Order created successfully";
            response.Id = order.Id;

            return response;
        }
    }
}
