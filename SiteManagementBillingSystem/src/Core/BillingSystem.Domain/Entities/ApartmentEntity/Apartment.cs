using BillingSystem.Domain.Entities.UserEntity;
using BillingSystem.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Domain.Entities.ApartmentEntity;

[Table("Apartment", Schema = "dbo")]
public class Apartment : BaseEntity
{
    public string Block { get; set; }
    public int Floor { get; set; }
    public int Number { get; set; }
    public string Type { get; set; }
    public int Resident { get; set; }
    public int Status { get; set; } // full or empty

    public virtual IEnumerable<User> Users { get; set; }
}

public enum Resident
{
    Owner = 1,
    Tenant = 2,
}
public enum Status
{
    Empty = 0,
    Full = 1,
}