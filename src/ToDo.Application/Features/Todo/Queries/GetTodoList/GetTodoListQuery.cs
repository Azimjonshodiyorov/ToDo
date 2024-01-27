using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Enums;
using ToDo.Infrastructure.PaginatedLists;

namespace ToDo.Application.Features.Todo.Queries.GetTodoList
{
    public class GetTodoListQuery :IRequest<PaginatedList<TodoVm>>
    {
        public TodoStatus Status { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public string Keyword { get; set; }

        public long? CategoryId { get; set; }
    }
}
