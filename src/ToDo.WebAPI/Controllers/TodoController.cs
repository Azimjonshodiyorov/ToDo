using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Features.Todo.Commands.CreateTodo;
using ToDo.Application.Features.Todo.Commands.DeleteTodo;
using ToDo.Application.Features.Todo.Commands.UpdateTodo;
using ToDo.Application.Features.Todo.Queries.GetTodoDetail;
using ToDo.Application.Features.Todo.Queries.GetTodoList;
using ToDo.Domain.Enums;
using ToDo.Infrastructure.PaginatedLists;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Gets", Name = "GetTodos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedList<TodoVm>>> GetTodos(int pageSize = 20, int pageIndex = 0, string keyword = "", TodoStatus status = TodoStatus.Completed, long categoryId = 0)
        {
            var dtos = await _mediator.Send(new GetTodoListQuery()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Keyword = keyword,
                Status = status,
                CategoryId = categoryId
            });
            return Ok(dtos);
        }

        [HttpGet(Name = "GetTodo")]
        public async Task<ActionResult<TodoVm>> GetTodo(long todoId)
        {
            var dto = await _mediator.Send(new GetTodoDetailQuery()
            {
                TodoId = todoId
            });

            return Ok(dto);
        }

        [HttpPost(Name = "CreateTodo")]
        public async Task<ActionResult<CreateTodoCommandResponse>> CreateTodo([FromBody] CreateTodoCommand createTodoCommand)
        {
            var todoResponse = await _mediator.Send(createTodoCommand);
            return Ok(todoResponse);
        }

        [HttpPut(Name = "UpdateTodo")]
        public async Task<ActionResult<UpdateTodoCommandResponse>> UpdateTodo([FromBody] UpdateTodoCommand updateTodoCommand)
        {
            var todoResponse = await _mediator.Send(updateTodoCommand);
            return Ok(todoResponse);
        }

        [HttpDelete("{id}", Name = "DeleteTodo")]
        public async Task<ActionResult<bool>> DeleteTodo(long id)
        {
            var deletedSuccess = await _mediator.Send(new DeleteTodoCommand() { TodoId = id });
            return Ok(deletedSuccess);
        }
    }
}
