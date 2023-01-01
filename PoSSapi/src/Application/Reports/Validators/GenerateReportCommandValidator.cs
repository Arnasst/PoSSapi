using FluentValidation;
using PoSSapi.Application.Reports.Commands;

namespace PoSSapi.Application.Reports;

public class GenerateReportCommandValidator : AbstractValidator<GenerateReportCommand>
{
    public GenerateReportCommandValidator()
    {
        RuleFor(x => x.StartTime)
          .LessThan(DateTime.Now);
        RuleFor(x => x.EndTime)
          .LessThan(DateTime.Now);
        
        RuleFor(x => x.EndTime)
          .GreaterThan(x => x.StartTime);
    }
}
