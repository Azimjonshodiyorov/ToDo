using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommondValidator : AbstractValidator<UpdateCategoryComand>
    {
        

        public UpdateCategoryCommondValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(x => x.Name)
                 .NotEmpty()
                 .WithMessage("{PropertyName} is requard")
                 .NotNull()
                 .MaximumLength(1000)
                 .WithMessage("{PropertyName} must not exceed 1000 characters.")
                 .Must(x=> !categoryRepository.CheckCategoryDuplicate(x))
                 .WithMessage("PropertyName is Duplicate");

            RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotEqual(0);
        }
    }
}
