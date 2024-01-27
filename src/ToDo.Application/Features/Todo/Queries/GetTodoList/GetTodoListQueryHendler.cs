using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.PaginatedLists;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Todo.Queries.GetTodoList
{
    public class GetTodoListQueryHendler : IRequestHandler<GetTodoListQuery, PaginatedList<TodoVm>>
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMapper mapper;

        public GetTodoListQueryHendler(ITodoRepository todoRepository , IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }
        public async Task<PaginatedList<TodoVm>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var todos = (await todoRepository.GetTodoPaginatedList(request.Status, request.PageSize, request.PageIndex, request.Keyword, request.CategoryId));
            return mapper.Map<PaginatedList<TodoVm>>(todos);
        }
    }
}
