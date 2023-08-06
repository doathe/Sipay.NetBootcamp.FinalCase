namespace BillingSystem.PaymentAPI;

public class PaymentRequest
{
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string Cvc { get; set; }
    public decimal Amount { get; set; }
}