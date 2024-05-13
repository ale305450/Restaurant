using MediatR;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.Users.Requests.Commands;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Users.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var user = await _userRepository.Get(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(user), request.Id);

            await _userRepository.Delete(user);

            response.Success = true;
            response.Message = "User Deleted successfully";
            response.Id = user.Id;

            return response;
        }
    }
}
