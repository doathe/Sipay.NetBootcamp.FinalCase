namespace BillingSystem.Schema;

public class InvoiceResponse
{
    public string Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public string InvoiceType { get; set; }
    public string Status { get; set; }
    public string Apartment { get; set; }
}
