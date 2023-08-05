using System.Text.Json.Serialization;

namespace BillingSystem.Schema;

public class DuesRequest
{
    public string Month { get; set; }
    public int Year { get; set; }
    public decimal Amounth { get; set; }
}