using AutoMapper;
using MediatR;
using Restaurant.Application.Features.Reviews.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Application.Responses;
using Restaurant.Application.DTOs.Review.Validators;
using System.Linq;

namespace Restaurant.Application.Features.Reviews.Handlers.Commands
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, BaseCommandResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateReviewDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CreateReviewDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Item rating failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var review = _mapper.Map<Review>(request.CreateReviewDto);

                review = await _reviewRepository.Add(review);

                response.Success = true;
                response.Message = "Item rating successfully";
                response.Id = review.Id;
            }

            return response;
        }
    }
}
