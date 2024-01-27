using AutoMapper;
using MediatR;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryComand, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository , IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryComand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryCommondValidator(categoryRepository);
            var updateCategoryResponse = new UpdateCategoryCommandResponse();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(validatorResult.Errors.Any())
            {
                updateCategoryResponse.Success = false;
                updateCategoryResponse.ValidationErrors = validatorResult.Errors.Select(x=>x.ErrorMessage).ToList();
                updateCategoryResponse.Category = mapper.Map<UpdateCategoryCommondDto>(request);
                return updateCategoryResponse;
            }

            var updateToCategory = await this.categoryRepository.GetByIdAsync(request.CategoryId);

            if(updateToCategory == null)
            {
                updateCategoryResponse.Success = false;
                updateCategoryResponse.ValidationErrors.Add($"Categorey not found id {request.CategoryId}");
            }
            else
            {
                mapper.Map(typeof(UpdateCategoryCommondDto), typeof(Categorey));
                await this.categoryRepository.UpdateAsync(updateToCategory);
            }
            return updateCategoryResponse;
        }
    }
}
