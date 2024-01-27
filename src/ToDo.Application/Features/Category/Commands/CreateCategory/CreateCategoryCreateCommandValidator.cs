using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCreateCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCreateCommandValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(1000)
                .WithMessage("{PropertyName} must not exceed 1000 characters.")
                .Must(name => categoryRepository.CheckCategoryDuplicate(name)).WithMessage("{PropertyName} is duplicate.");
        }
    }

}
