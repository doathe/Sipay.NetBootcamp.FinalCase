using BillingSystem.Domain;
using BillingSystem.Schema;

namespace BillingSystem.Application;

public interface IApartmentService : IGenericService<Apartment, ApartmentRequest, ApartmentResponse>
{
}
