using FluentValidation;

namespace PoSSapi.Application.Ingredients.Commands;

public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
{
    public UpdateIngredientCommandValidator()
    {
        RuleFor(x => x.Price)
          .GreaterThan(0);

        RuleFor(x => x.Quantity)
          .GreaterThan(0);
    }
}
