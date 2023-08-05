using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Domain;

[Table("User", Schema = "dbo")]
public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TCKNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string? CarPlateNumber { get; set; }
    public string Role { get; set; }

    public int ApartmentId { get; set; }
    public Apartment Apartment { get; set; }
}