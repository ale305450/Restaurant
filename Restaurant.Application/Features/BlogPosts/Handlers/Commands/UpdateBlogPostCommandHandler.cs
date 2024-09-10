using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.BlogPost.Validators;
using Restaurant.Application.Features.BlogPosts.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.BlogPosts.Handlers.Commands
{
    public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand, BaseCommandResponse>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public UpdateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateBlogPostDtoValidator();

            var validationResult = await validator.ValidateAsync(request.UpdateBlogPostDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "BlogPost update failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var blogPost = await _blogPostRepository.Get(request.Id);

                _mapper.Map(request.UpdateBlogPostDto, blogPost);

                await _blogPostRepository.Update(blogPost);

                response.Success = true;
                response.Message = "BlogPost updated successfully";
                response.Id = blogPost.Id;
            }
            return response;
        }

    }
}
