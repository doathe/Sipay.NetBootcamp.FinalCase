namespace BillingSystem.Schema;

public class UserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TCKNumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? CarPlateNumber { get; set; }
    public string Role { get; set; }
    public string ApartmentId { get; set; }
}
