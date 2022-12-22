using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Ingredients.Commands;

public record UpdateIngredientCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public StockStatus StockStatus { get; init; }
}

public class UpdateIngredientCommandHandler : IRequestHandler<UpateIngredientCommand, Unit>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateIngredientCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await _context.Ingredients
          .FindAsync(request.Id, cancellationToken)
          ?? throw new NotFoundException(nameof(Ingredient), request.Id);

        _mapper.Map(request, ingredient);

        _context.Ingredients.Update(ingredient);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
