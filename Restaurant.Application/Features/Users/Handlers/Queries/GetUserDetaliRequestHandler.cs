using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.User;
using Restaurant.Application.Features.Users.Requests.Queries;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Users.Handlers.Queries
{
    public class GetUserDetaliRequestHandler : IRequestHandler<GetUserDetaliRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetaliRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserDetaliRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
