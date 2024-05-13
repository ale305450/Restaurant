using MediatR;
using Restaurant.Application.DTOs.Reservation;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reservations.Requests.Commands
{
    public class CreateReservationCommand : IRequest<BaseCommandResponse>
    {
        public CreateReservationDto CreateReservationDto { get; set; }
    }
}
