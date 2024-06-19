using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;
namespace Restaurant.Application.DTOs.Review
{
    public class UpdateReviewDto : BaseDto, IReviewDto
    {
        public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public int Rating { get; set; }
    }
}
