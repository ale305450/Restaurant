using MediatR;
using Restaurant.Application.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Reviews.Requests.Queries
{
    public class GetReviewListRequest : IRequest<List<ReviewDto>>
    {
    }
}
