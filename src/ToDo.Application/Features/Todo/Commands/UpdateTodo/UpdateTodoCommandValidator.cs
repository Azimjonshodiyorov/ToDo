using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.Todo.Commands.UpdateTodo
{
    public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoCommandValidator()
        {
            RuleFor(p => p.Title)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.Description)
                 .MaximumLength(5000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.TodoId)
                .NotNull()
                .NotEqual(0).WithMessage("{PropertyName} is required.");
        }
    }
}
