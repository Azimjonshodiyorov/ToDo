using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Category.Queries.GetCategoriesList
{
    public class GetCategoryListQueryHendler : IRequestHandler<GetCategoryListQuery, List<CategoryListVm>>
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryListQueryHendler(IMapper mapper , ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryListVm>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = this.categoryRepository.GetAll().Where(x => !x.DeleteAt.HasValue);
            var categories = await allCategories.Include(x=>x.Todos)
                .Select(x=> new CategoryListVm()
                {
                    Name = x.Name,
                    CategoryId = x.Id,
                    CanDelete = x.Todos.Count() == 0,
                    
                })
                .OrderBy(x=>x.Name)
                .ToListAsync();

            return categories;
        }
    }
}
