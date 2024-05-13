using MediatR;
using Restaurant.Application.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reviews.Requests.Commands
{
    public class UpdateReviewCommand : IRequest<Unit>
    {
        public UpdateReviewDto UpdateReviewDto { get; set; }
    }
}
