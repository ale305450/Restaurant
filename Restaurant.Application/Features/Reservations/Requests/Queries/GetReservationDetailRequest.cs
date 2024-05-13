﻿using MediatR;
using Restaurant.Application.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reservations.Requests.Queries
{
    public class GetReservationDetailRequest : IRequest<ReservationDto>
    {
        public int Id { get; set; }
    }
}
