using AutoMapper;
using MediatR;
using Restaurant.Application.Features.Categories.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Application.DTOs.Category.Validators;

namespace Restaurant.Application.Features.Categories.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository
            , IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateCategoryDtoValidator();

            var validationResult = await validator.ValidateAsync(request.UpdateCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Category update failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var category = await _categoryRepository.Get(request.Id);

                _mapper.Map(request.UpdateCategoryDto, category);

                await _categoryRepository.Update(category);

                response.Success = true;
                response.Message = "Category updated successfully";
                response.Id = category.Id;
            }
            return response;
        }
    }
}
