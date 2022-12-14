using FluentValidation;
using PoSSapi.Application.BusinessLocations.Commands;

namespace PoSSapi.Application.BusinessLocations.Validators;

public class CreateBusinessLocationCommandValidator : AbstractValidator<CreateBusinessLocationCommand>
{
    public CreateBusinessLocationCommandValidator()
    {
        RuleFor(v => v.BuildingNumber)
            .GreaterThan(0);
    }
}
