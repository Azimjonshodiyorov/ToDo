using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.Todo.Commands.DeleteTodo
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public long TodoId { get; set; }
    }
}
