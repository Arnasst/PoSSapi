namespace PoSSapi.Domain.Entities;

public class Payment
{
    public int ID { get; set; }
    public int CustomerID { get; set; }
    public int OrderID { get; set; }
    public float PriceOfOrder { get; set; }
    public float Discount { get; set; }
    public float Tip { get; set; }
    public string PaymentOptions { get; set; } // Enum
    public string Status { get; set; } // Enum
    public DateTime TimeWhenCompleted { get; set; }
}
