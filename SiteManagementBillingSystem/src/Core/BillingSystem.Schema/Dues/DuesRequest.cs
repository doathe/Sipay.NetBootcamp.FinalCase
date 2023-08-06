namespace BillingSystem.Schema;

public class DuesRequest
{
    public string Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
}