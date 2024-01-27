using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Enums;

namespace ToDo.Application.Features.Todo.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<CreateTodoCommandResponse>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TodoStatus Status { get; set; }

        public long TodoId { get; set; }

        public long CategoryId { get; set; }
    }
}
