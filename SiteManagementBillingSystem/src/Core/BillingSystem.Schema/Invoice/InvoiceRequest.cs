namespace BillingSystem.Schema;

public class InvoiceRequest
{
    public string Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public string InvoiceType { get; set; }
}