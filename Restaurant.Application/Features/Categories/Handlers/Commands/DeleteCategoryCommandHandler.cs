using MediatR;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.Categories.Requests.Commands;
using Restaurant.Application.Contracts.Presistence;
using Restaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Restaurant.Application.Responses;

namespace Restaurant.Application.Features.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var category = await _categoryRepository.Get(request.Id);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            await _categoryRepository.Delete(category);


            response.Success = true;
            response.Message = "category Deleted successfully";
            response.Id = category.Id;

            return response;
        }
    }
}
