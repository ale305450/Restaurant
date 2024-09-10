using MediatR;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Users.Requests.Commands
{
    public class DeleteUserCommand : IRequest<BaseCommandResponse>
    {
        public string Id { get; set; }
    }
}
