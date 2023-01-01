using AutoMapper;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Reports.Dtos;
public class ReportDto : IMapFrom<Report>
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Revenue { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<Report, ReportDto>();
    }
}
