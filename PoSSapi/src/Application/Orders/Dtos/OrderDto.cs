using AutoMapper;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Orders.Dtos;

public class OrderDto : IMapFrom<Order>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public ICollection<Guid>? DishIds { get; set; }
    public ICollection<Guid>[]? PaymentIds { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public OrderStatus Status { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDto>()
            .ForMember(d => d.DishIds, opt 
                => opt.MapFrom(s => s.Dishes.Select(d => d.Id)))
            .ForMember(d => d.PaymentIds, opt 
                => opt.MapFrom(s => s.Payments.Select(p => p.Id)));
    }
}