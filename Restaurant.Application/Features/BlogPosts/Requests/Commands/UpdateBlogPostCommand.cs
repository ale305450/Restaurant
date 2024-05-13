﻿using MediatR;
using Restaurant.Application.DTOs.BlogPost;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.BlogPosts.Requests.Commands
{
    public class UpdateBlogPostCommand :IRequest<BaseCommandResponse>
    {
        public UpdateBlogPostDto UpdateBlogPostDto { get; set; }
    }
}
