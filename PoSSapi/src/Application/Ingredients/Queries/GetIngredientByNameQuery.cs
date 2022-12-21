using MediatR;
using Microsoft.EntityFrameworkCore;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Ingredients.Queries;

public record GetIngredientByNameQuery(string IngredientName) : IRequest<Ingredient>;

public class GetIngredientByNameQueryHandler : IRequestHandler<GetIngredientByNameQuery, Ingredient>
{
    private readonly IApplicationDbContext _context;

    public GetIngredientByNameQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Ingredient> Handle(GetIngredientByNameQuery request, CancellationToken cancellationToken)
    {
        var ingredient = _context.Ingredients
          .Where(x => x.Name.ToLower().Contains(request.IngredientName));

        if (ingredient.Count() == 0)
        {
            throw new NotFoundException(nameof(Reservation), request.IngredientName);
        }

        return await ingredient.FirstAsync();
    }
}
