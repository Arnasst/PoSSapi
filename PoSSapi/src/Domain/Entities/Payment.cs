namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class Payment
{
    public int ID { get; set; }
    public int CustomerID { get; set; }
    public int OrderID { get; set; }
    public float PriceOfOrder { get; set; }
    public float Discount { get; set; }
    public float Tip { get; set; }
    public PaymentOption PaymentOptions { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime TimeWhenCompleted { get; set; }
}
