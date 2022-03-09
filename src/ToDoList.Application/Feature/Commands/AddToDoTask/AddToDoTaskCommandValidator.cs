using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracrts.Persistence;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Feature.Commands.AddToDoTask
{
    public class AddToDoTaskCommandValidator : AbstractValidator<AddToDoTaskCommand>
    {

        public AddToDoTaskCommandValidator()
        {
           


            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
        }
    }
}
