using Restaurant.Application.DTOs.Common;
using Restaurant.Application.DTOs.MenuItem;
using Restaurant.Application.DTOs.User;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.Review
{
    public class ReviewDto : BaseDto
    {
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int ItemId { get; set; }
        public MenuItemDto MenuItem { get; set; }
        public int Rating { get; set; }
    }
}
