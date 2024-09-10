using MediatR;
using Restaurant.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Users.Requests.Queries
{
    public class GetUserDetailRequest : IRequest<UserDto>
    {
        public string Id { get; set; }
    }
}
