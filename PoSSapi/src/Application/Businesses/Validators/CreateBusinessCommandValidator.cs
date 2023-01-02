using FluentValidation;
using PoSSapi.Application.Businesses.Commands;

namespace PoSSapi.Application.Businesses.Validators;

public class CreateBusinessCommandValidator : AbstractValidator<CreateBusinessCommand>
{
    public CreateBusinessCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}