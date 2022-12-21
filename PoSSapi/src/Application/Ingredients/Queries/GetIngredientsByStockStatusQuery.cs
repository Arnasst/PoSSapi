using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Ingredients.Queries;

public record GetIngredientsByStockStatusQuery(StockStatus StockStatus) : IRequest<IQueryable<Ingredient>>;

public class GetIngredientsByStockStatusQueryHandler : IRequestHandler<GetIngredientsByStockStatusQuery, IQueryable<Ingredient>>
{
    private readonly IApplicationDbContext _context;

    public GetIngredientsByStockStatusQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Ingredient>> Handle(GetIngredientsByStockStatusQuery request, CancellationToken cancellationToken)
    {
        return _context.Ingredients
          .Where(x => x.StockStatus == request.StockStatus);
    }
}
