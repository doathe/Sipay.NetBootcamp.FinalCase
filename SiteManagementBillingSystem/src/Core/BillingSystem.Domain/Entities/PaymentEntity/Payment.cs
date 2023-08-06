using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Domain;

[Table("Payment", Schema = "dbo")]
public class Payment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int PaymentType { get; set; }
    public decimal Amount { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int? InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }
    public int? DuesId { get; set; }
    public Dues? Dues { get; set; }

}

public enum PaymentType
{
    Dues = 1,
    Invoice = 2,
}