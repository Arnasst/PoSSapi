using FluentValidation;
using PoSSapi.Application.Reservations.Commands;

namespace PoSSapi.Application.Reservations;

public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
{
    public UpdateReservationCommandValidator()
    {
        RuleFor(x => x.NumOfPeople)
          .GreaterThan(0);

        RuleFor(x => x.Time)
          .GreaterThan(DateTime.Now);
    }
}
