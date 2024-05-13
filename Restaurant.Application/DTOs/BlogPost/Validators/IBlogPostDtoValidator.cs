using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.DTOs.BlogPost.Validators
{
    public class IBlogPostDtoValidator :AbstractValidator<IBlogPostDto>
    {
        public IBlogPostDtoValidator()
        {
            RuleFor(b => b.Title)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");

            RuleFor(b => b.Author)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");

            RuleFor(b => b.Content)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
