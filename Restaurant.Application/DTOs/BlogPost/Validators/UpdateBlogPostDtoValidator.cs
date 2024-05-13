using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.BlogPost.Validators
{
    public class UpdateBlogPostDtoValidator : AbstractValidator<UpdateBlogPostDto>
    {
        public UpdateBlogPostDtoValidator()
        {
            Include(new IBlogPostDtoValidator());

            RuleFor(b => b.Id).NotNull().WithMessage("{PropertyName} should be present");
        }
    }
}
