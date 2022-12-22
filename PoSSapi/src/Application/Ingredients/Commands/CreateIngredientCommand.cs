using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Ingredients.Commands;

public record CreateIngredientCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public StockStatus StockStatus { get; init; }
}

public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateIngredientCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = new Ingredient();

        _mapper.Map(request, ingredient);

        await _context.Ingredients.AddAsync(ingredient, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ingredient.Id;
    }
}
