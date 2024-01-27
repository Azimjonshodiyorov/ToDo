using AutoMapper;
using MediatR;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Todo.Commands.CreateTodo
{
    public class CreateTodoCommandHendler : IRequestHandler<CreateTodoCommand, CreateTodoCommandResponse>
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMapper mapper;

        public CreateTodoCommandHendler(ITodoRepository todoRepository , IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }
        public async Task<CreateTodoCommandResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var createTodoCommandResponse = new CreateTodoCommandResponse();
            var createTodoCommandValidator = new CreateTodoCommandValidator();
            var validatorResult = await  createTodoCommandValidator.ValidateAsync(request , cancellationToken);

            if(validatorResult.Errors.Any())
            {
                createTodoCommandResponse.Success = false;
                createTodoCommandResponse.ValidationErrors = validatorResult.Errors.Select(error => error.ErrorMessage).ToList();
                createTodoCommandResponse.CreateTodo = mapper.Map<CreateTodoDto>(request);
            }
            else
            {
                var todo = mapper.Map<Domain.Entities.Todo>(request);

                todo = await todoRepository.AddAsync(todo);

                createTodoCommandResponse.CreateTodo = mapper.Map<CreateTodoDto>(todo);
            }
            throw new NotImplementedException();
        }
    }
}
