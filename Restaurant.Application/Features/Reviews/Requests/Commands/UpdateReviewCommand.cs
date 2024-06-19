using MediatR;
using Restaurant.Application.DTOs.Review;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reviews.Requests.Commands
{
    public class UpdateReviewCommand : IRequest<BaseCommandResponse>
    {
        public UpdateReviewDto UpdateReviewDto { get; set; }
    }
}
