using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.User.Validators;
using Restaurant.Application.Features.Users.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateUserDtoValidator();

            var validationResult = await validator.ValidateAsync(request.UpdateUserDto);


            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "User update failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var menuItem = await _userRepository.Get(request.UpdateUserDto.Id);

            _mapper.Map(request.UpdateUserDto, menuItem);

            await _userRepository.Update(menuItem);

            response.Success = true;
            response.Message = "User updated successfully";
            response.Id = menuItem.Id;

            return response;
        }
    }
}
