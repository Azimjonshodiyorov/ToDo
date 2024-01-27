
using MediatR;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Todo.Commands.DeleteTodo
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly ITodoRepository todoRepository;

        public DeleteTodoCommandHandler( ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            bool deleteTodoSucces = true;

            try
            {
                var todo = await todoRepository.GetByIdAsync(request.TodoId);

                if (todo == null)
                {
                    deleteTodoSucces = false;
                    // Handle error
                }
                else
                {
                    todo.DeleteAt = DateTime.UtcNow;
                    await todoRepository.UpdateAsync(todo);
                }
            }
            catch (Exception)
            {
                deleteTodoSucces = false;
            }

            return deleteTodoSucces;
        }
    }
}
