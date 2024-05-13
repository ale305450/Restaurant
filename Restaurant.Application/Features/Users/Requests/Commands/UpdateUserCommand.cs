using MediatR;
using Restaurant.Application.DTOs.User;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Users.Requests.Commands
{
    public class UpdateUserCommand : IRequest<BaseCommandResponse>
    {
        public UpdateUserDto UpdateUserDto { get; set; }
    }
}
