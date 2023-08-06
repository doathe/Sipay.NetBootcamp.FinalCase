namespace BillingSystem.Schema;

public class BasePaymentResponse
{
    public DateTime Date { get; set; }
    public string PaymentType { get; set; }
    public decimal Amount { get; set; }
    public string User { get; set; }
}