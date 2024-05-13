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
    public class GetReviewListRequestHandler : IRequestHandler<GetReviewListRequest,List<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetReviewListRequestHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDto>> Handle(GetReviewListRequest request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.GetReviewRequestWithDetails();
            return _mapper.Map<List<ReviewDto>>(reviews);
        }
    }
}
