using MediatR;
using Restaurant.Application.DTOs.Reservation;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reservations.Requests.Commands
{
    public class UpdateReservationCommand :IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }

        public UpdateReservationDto UpdateReservationDto { get; set; }

        public ChangeReservationStatusDto ChangeReservationStatusDto { get; set; }
    }
}
