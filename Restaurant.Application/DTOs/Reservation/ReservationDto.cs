using Restaurant.Application.DTOs.Common;
using Restaurant.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Reservation
{
    public class ReservationDto : BaseDto
    {
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int NumGuests { get; set; }
        public string Status { get; set; }
    }
}
