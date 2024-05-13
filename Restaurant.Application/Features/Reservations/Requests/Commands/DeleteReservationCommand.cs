using MediatR;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reservations.Requests.Commands
{
    public class DeleteReservationCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
