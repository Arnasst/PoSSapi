using FluentValidation;
using PoSSapi.Application.Users.Commands;

namespace PoSSapi.Application.Users.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.Age)
            .GreaterThan(14)
            .LessThan(150);
        RuleFor(v => v.Username)
            .NotEmpty()
            .MaximumLength(20);
        RuleFor(v => v.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
