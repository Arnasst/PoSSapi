using FluentValidation;
using PoSSapi.Application.Businesses.Commands;

namespace PoSSapi.Application.Businesses.Validators;

public class UpdateBusinessCommandValidator : AbstractValidator<UpdateBusinessCommand>
{
    public UpdateBusinessCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}