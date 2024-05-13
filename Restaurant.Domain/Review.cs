using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain
{
    public class Review: BaseDomainEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Rating { get; set; }
    }
}
