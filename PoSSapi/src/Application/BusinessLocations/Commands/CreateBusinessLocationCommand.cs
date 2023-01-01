using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.BusinessLocations.Commands;

public class CreateBusinessLocationCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }
    public int Floor { get; set; }
    public string PostCode { get; set; }
    public Guid BusinessId { get; set; }
}

public class CreateBusinessLocationCommandHandler : IRequestHandler<CreateBusinessLocationCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateBusinessLocationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateBusinessLocationCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses.FindAsync(request.BusinessId, cancellationToken) ?? 
                       throw new NotFoundException(nameof(Business), request.BusinessId);
        
        var businessLocation = new BusinessLocation
        {
            Id = request.Id,
            Country = request.Country,
            City = request.City,
            Street = request.Street,
            BuildingNumber = request.BuildingNumber,
            Floor = request.Floor,
            PostCode = request.PostCode,
            BusinessId = request.BusinessId,
            Business = business
        };
        
        _context.BusinessLocations.Add(businessLocation);
        await _context.SaveChangesAsync(cancellationToken);
        
        return businessLocation.Id;
    }
}
