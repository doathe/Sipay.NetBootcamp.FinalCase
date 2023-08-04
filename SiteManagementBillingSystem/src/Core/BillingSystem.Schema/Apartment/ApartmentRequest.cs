namespace BillingSystem.Schema.Apartment;

public class ApartmentRequest
{
    public string Block { get; set; }
    public int Floor { get; set; }
    public int Number { get; set; }
    public string Type { get; set; }
    public string Resident { get; set; }
    public string Status { get; set; }
}
