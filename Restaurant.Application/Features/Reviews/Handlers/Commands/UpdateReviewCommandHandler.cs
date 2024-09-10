using AutoMapper;
using MediatR;
using Restaurant.Application.Features.Reviews.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
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
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, BaseCommandResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateReviewDtoValidator();

            var validationResult = await validator.ValidateAsync(request.UpdateReviewDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Change item rating failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var review = await _reviewRepository.Get(request.Id);

                _mapper.Map(request.UpdateReviewDto, review);

                await _reviewRepository.Update(review);


                response.Success = true;
                response.Message = "item rating changed successfully";
                response.Id = review.Id;
            }
            return response;
        }
    }
}
