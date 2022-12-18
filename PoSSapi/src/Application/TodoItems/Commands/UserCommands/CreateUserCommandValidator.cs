﻿using FluentValidation;

namespace PoSSapi.Application.TodoItems.Commands.UserCommands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.Age)
            .GreaterThan(14)
            .LessThan(100);
        RuleFor(v => v.Username)
            .NotEmpty()
            .MaximumLength(20);
        RuleFor(v => v.Email)
            .NotEmpty()
            .EmailAddress();
    }
}