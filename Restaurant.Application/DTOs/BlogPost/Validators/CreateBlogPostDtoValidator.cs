using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.BlogPost.Validators
{
    public class CreateBlogPostDtoValidator : AbstractValidator<CreateBlogPostDto>
    {
        public CreateBlogPostDtoValidator()
        {
            Include(new IBlogPostDtoValidator());
        }
    }
}
