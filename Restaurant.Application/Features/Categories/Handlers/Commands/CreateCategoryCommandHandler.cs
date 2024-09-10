using AutoMapper;
using MediatR;
using Restaurant.Application.DTOs.Category.Validators;
using Restaurant.Application.Features.Categories.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Domain;

namespace Restaurant.Application.Features.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository
            , IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateCategoryDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CreateCategoryDto);

            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Category creation failed";
                response.Errors = validationResult.Errors.Select(e =>e.ErrorMessage).ToList();
            }
            else
            {
                var category = _mapper.Map<Category>(request.CreateCategoryDto);

                category = await _categoryRepository.Add(category);

                response.Success = true;
                response.Message = "Category created successfully";
                response.Id = category.Id;
            }
            return response;
        }
    }
}
