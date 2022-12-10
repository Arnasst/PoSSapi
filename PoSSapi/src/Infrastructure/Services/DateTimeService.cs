using PoSSapi.Application.Common.Interfaces;

namespace PoSSapi.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
