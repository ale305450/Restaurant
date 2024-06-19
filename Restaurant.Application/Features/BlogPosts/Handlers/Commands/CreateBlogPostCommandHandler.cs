using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.BlogPost.Validators;
using Restaurant.Application.Features.BlogPosts.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.BlogPosts.Handlers.Commands
{
    public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, BaseCommandResponse>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();

            var validator = new CreateBlogPostDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CreateBlogPostDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "BlogPost creation failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var blogPost = _mapper.Map<BlogPost>(request.CreateBlogPostDto);

                blogPost = await _blogPostRepository.Add(blogPost);

                response.Success = true;
                response.Message = "BlogPost created successfully";
                response.Id = blogPost.Id;
            }

            return response;
        }
    }
}
