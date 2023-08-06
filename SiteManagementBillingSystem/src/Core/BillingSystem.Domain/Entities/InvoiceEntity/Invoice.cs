using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Domain;

[Table("Invoice", Schema = "dbo")]
public class Invoice : BaseEntity
{
    public string Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public int InvoiceType { get; set; }
    public int InvoicePaymentStatus { get; set; }

    public int ApartmentId { get; set; }
    public Apartment Apartment { get; set; }
    public int? PaymentId { get; set; }
    public Payment? Payment { get; set; }
}

public enum InvoicePaymentStatus
{
    Unpaid = 0,
    Paid = 1,
}
public enum InvoiceType
{
    Water = 1,
    Electric = 2,
    Gas = 3
}