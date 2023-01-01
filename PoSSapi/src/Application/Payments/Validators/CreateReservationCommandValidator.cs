using FluentValidation;
using PoSSapi.Application.Payments.Commands;

namespace PoSSapi.Application.Payments;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.PriceOfOrder)
          .GreaterThan(0);

        RuleFor(x => x.Discount)
          .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Tip)
          .GreaterThanOrEqualTo(0);
    }
}
