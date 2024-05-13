using AutoMapper;
using MediatR;
using Restaurant.Application.Features.Reviews.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Reviews.Handlers.Commands
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Unit>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.Get(request.UpdateReviewDto.Id);

            _mapper.Map(request.UpdateReviewDto, review);

            await _reviewRepository.Update(review);

            return Unit.Value;
        }
    }
}
