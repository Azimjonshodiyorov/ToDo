using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Responses;

namespace ToDo.Application.Features.Todo.Commands.CreateTodo
{
    public class CreateTodoCommandResponse : BaseResponse
    {
        public CreateTodoCommandResponse() { }
        public CreateTodoDto CreateTodo { get; set; }
    }
}
