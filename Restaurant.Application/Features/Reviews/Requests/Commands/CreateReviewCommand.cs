using MediatR;
using Restaurant.Application.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reviews.Requests.Commands
{
    public class CreateReviewCommand : IRequest<int>
    {
        public CreateReviewDto CreateReviewDto { get; set; }
    }
}
