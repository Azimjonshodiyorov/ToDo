using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Todo.Commands.UpdateTodo
{
    public class UpdateTodoCommandHendler : IRequestHandler<UpdateTodoCommand, UpdateTodoCommandResponse>
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMapper mapper;

        public UpdateTodoCommandHendler(ITodoRepository todoRepository , IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateTodoCommandResponse> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var updateTodoCommandResponse = new UpdateTodoCommandResponse();
            var validator = new UpdateTodoCommandValidator();

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                updateTodoCommandResponse.Success = false;
                updateTodoCommandResponse.ValidationErrors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                updateTodoCommandResponse.UpdateTodoDto = mapper.Map<UpdateTodoDto>(request);
                return updateTodoCommandResponse;
            }

            var todoUpdate = await todoRepository.GetByIdAsync(request.TodoId);

            if (todoUpdate == null)
            {
                updateTodoCommandResponse.Success = false;
                updateTodoCommandResponse.ValidationErrors.Add($"Todo not found id {request.TodoId}");
            }
            else
            {
                mapper.Map(request, todoUpdate, typeof(UpdateTodoCommand), typeof(Domain.Entities.Todo));

                await todoRepository.UpdateAsync(todoUpdate);
                updateTodoCommandResponse.ValidationErrors = new List<string>();
                updateTodoCommandResponse.Success = true;
                updateTodoCommandResponse.UpdateTodoDto = mapper.Map<UpdateTodoDto>(todoUpdate);
            }

            return updateTodoCommandResponse;
        }
    }
}
