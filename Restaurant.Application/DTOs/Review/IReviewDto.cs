using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.DTOs.Review
{
    public interface IReviewDto
    {
        public string UserId { get; set; }
        public int MenuItemId { get; set; }
        public int Rating { get; set; }
    }
}
