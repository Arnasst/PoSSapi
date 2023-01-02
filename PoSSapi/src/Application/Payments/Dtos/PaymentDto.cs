namespace PoSSapi.Application.Payments.Dtos;

using AutoMapper;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Domain.Enums;
using PoSSapi.Domain.Entities;

public class PaymentDto: IMapFrom<Payment>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid OrderId { get; set; }
    public decimal PriceOfOrder { get; set; }
    public decimal Discount { get; set; }
    public decimal Tip { get; set; }
    public PaymentOption PaymentOptions { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime TimeWhenCompleted { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<Payment, PaymentDto>();
    }
}
