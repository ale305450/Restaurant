using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain
{
    public class Reservation: BaseDomainEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int NumGuests { get; set; }
        public string Status { get; set; }
    }

}
