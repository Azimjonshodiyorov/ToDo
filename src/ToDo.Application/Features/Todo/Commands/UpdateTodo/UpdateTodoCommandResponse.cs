using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Responses;

namespace ToDo.Application.Features.Todo.Commands.UpdateTodo
{
    public class UpdateTodoCommandResponse : BaseResponse
    {
        public UpdateTodoDto UpdateTodoDto { get; set; }
    }
}
