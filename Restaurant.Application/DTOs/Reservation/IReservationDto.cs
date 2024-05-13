﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Reservation
{
    public interface IReservationDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int NumGuests { get; set; }
    }
}
