using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Ingredients.Queries;

public record GetIngredientByIdQuery(Guid IngredientId) : IRequest<Ingredient>;

public class GetIngredientByIdQueryHandler : IRequestHandler<GetIngredientByIdQuery, Ingredient>
{
    private readonly IApplicationDbContext _context;

    public GetIngredientByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Ingredient> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
    {
        var ingredient = await _context.Ingredients
          .FindAsync(request.IngredientId, cancellationToken)
          ?? throw new NotFoundException(nameof(Reservation), request.IngredientId);

        return ingredient;
    }
}
