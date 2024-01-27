using AutoMapper;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handler(CreateCategoryCommand requst, CancellationToken cancellationToken)
        {
            var createCategoryCommondResponse = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCreateCommandValidator(categoryRepository);

            var validationResult = await validator.ValidateAsync(requst, cancellationToken);
            if (validationResult.Errors.Any())
            {
                createCategoryCommondResponse.Success = false;
                createCategoryCommondResponse.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                createCategoryCommondResponse.CreateCategoryDto = mapper.Map<CreateCategoryDto>(requst);
            }

            /* if(createCategoryCommondResponse.Success)
             {
                 var category = new { Name = requst.Name };
                 category = await categoryRepository.AddAsync(category);
             }*/

            return createCategoryCommondResponse;

        }
    }
}
