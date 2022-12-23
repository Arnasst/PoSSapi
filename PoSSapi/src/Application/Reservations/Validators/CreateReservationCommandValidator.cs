using FluentValidation;
using PoSSapi.Application.Reservations.Commands;

namespace PoSSapi.Application.Reservations;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.NumOfPeople)
          .GreaterThan(0);

        RuleFor(x => x.Time)
          .GreaterThan(DateTime.Now);
    }
}
