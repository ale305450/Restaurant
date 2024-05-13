using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.Review;
using Restaurant.Application.Features.Reviews.Requests.Queries;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Reviews.Handlers.Queries
{
    public class GetReviewDetailRequestHandler : IRequestHandler<GetReviewDetailRequest, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetReviewDetailRequestHandler(IReviewRepository reviewRepository , IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public async Task<ReviewDto> Handle(GetReviewDetailRequest request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetReviewRequestWithDetails(request.Id);
            return _mapper.Map<ReviewDto>(review);
        }
    }
}
