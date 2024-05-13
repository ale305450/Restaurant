using Restaurant.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;
namespace Restaurant.Application.DTOs.Review
{
    public class UpdateReviewDto : BaseDto
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Rating { get; set; }
    }
}
