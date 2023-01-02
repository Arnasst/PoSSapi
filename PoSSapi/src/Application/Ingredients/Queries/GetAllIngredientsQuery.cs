using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Ingredients.Queries;

public record GetAllIngredientsQuery : IRequest<PaginatedList<Ingredient>>
{
    public string? IngredientName { get; set; }
    public StockStatus? StockStatus { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, PaginatedList<Ingredient>>
{
    private readonly IApplicationDbContext _context;

    public GetAllIngredientsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<Ingredient>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        var ingredients = _context.Ingredients;

        if (request.IngredientName != null)
        {
            ingredients
                .Where(x => x.Name.ToLower().Contains(request.IngredientName.ToLower()));
        }

        if (request.StockStatus != null)
        {
            ingredients
                .Where(x => x.StockStatus == request.StockStatus);
        }

        return await ingredients
          .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
