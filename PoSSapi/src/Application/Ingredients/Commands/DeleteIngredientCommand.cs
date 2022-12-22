using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Ingredients.Commands;

public record DeleteIngredientCommand(Guid Id) : IRequest;

public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteIngredientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await _context.Ingredients
          .FindAsync(request.Id, cancellationToken)
          ?? throw new NotFoundException(nameof(Ingredient), request.Id);

        _context.Ingredients.Remove(ingredient);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
