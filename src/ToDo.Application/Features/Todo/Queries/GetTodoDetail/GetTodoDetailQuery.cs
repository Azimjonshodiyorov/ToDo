using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.Todo.Queries.GetTodoList;

namespace ToDo.Application.Features.Todo.Queries.GetTodoDetail
{
    public class GetTodoDetailQuery : IRequest<TodoVm>
    {
        public long TodoId { get; set; }
    }
}
