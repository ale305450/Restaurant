using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Reservation
{
    public class UpdateReservationDto : BaseDto, IReservationDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int NumGuests { get; set; }
    }
}
