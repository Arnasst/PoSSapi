using FluentValidation;

namespace PoSSapi.Application.Ingredients.Commands;

public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
{
    public CreateIngredientCommandValidator()
    {
        RuleFor(x => x.Price)
          .GreaterThan(0);

        RuleFor(x => x.Quantity)
          .GreaterThan(0);
    }
}
