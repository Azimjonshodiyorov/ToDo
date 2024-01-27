using AutoMapper;
using MediatR;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository , IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            bool deleteSeccoss = true;

            try
            {
                var categoryToDelete = await this.categoryRepository.GetByIdAsync(request.CategoryId);
                if (categoryToDelete == null)
                {
                    throw new ArgumentNullException();
                }

                categoryToDelete.DeleteAt = DateTime.UtcNow;
                await this.categoryRepository.DeleteAsync(categoryToDelete);
            }
            catch (Exception)
            {

                deleteSeccoss = false;
            }

            return deleteSeccoss;
        }
    }
}
