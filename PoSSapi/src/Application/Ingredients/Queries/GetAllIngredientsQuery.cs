using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Ingredients.Queries;

public record GetAllIngredientsQuery(Guid IngredientId) : IRequest<IQueryable<Ingredient>>;

public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, IQueryable<Ingredient>>
{
    private readonly IApplicationDbContext _context;

    public GetAllIngredientsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Ingredient>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        return _context.Ingredients
          .AsQueryable();
    }
}
