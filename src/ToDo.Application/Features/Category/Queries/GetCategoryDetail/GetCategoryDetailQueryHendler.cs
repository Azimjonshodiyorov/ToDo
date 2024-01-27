using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Category.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryHendler : IRequestHandler<GetCategoryDetailQuery, CategoryVm>
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryDetailQueryHendler(IMapper mapper , ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }
        public async Task<CategoryVm> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await  this.categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundException(nameof(Categorey) , request.CategoryId);
            }
            var categoryVm = mapper.Map<CategoryVm>(category);
            return categoryVm;
        }
    }
}
