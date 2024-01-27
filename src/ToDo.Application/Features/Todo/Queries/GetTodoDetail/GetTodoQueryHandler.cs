using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.Todo.Queries.GetTodoList;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Todo.Queries.GetTodoDetail
{
    public class GetTodoQueryHandler : IRequestHandler<GetTodoDetailQuery, TodoVm>
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMapper mapper;

        public GetTodoQueryHandler(ITodoRepository todoRepository , IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }
        public async Task<TodoVm> Handle(GetTodoDetailQuery request, CancellationToken cancellationToken)
        {
            var todo = await todoRepository.GetByIdAsync(request.TodoId);

            if (todo == null)
            {
                throw new NotFoundException(nameof(Categorey), request.TodoId);
            }

            todo.Category = new Categorey();
            var todoVm = mapper.Map<TodoVm>(todo);

            return todoVm;
        }
    }
}
