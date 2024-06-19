using MediatR;
using Restaurant.Application.DTOs.Review;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reviews.Requests.Commands
{
    public class CreateReviewCommand : IRequest<BaseCommandResponse>
    {
        public CreateReviewDto CreateReviewDto { get; set; }
    }
}
