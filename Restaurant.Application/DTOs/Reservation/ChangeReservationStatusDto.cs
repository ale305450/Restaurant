using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Reservation
{
    public class ChangeReservationStatusDto :BaseDto
    {
        public string Status { get; set; }

    }
}
