using BillingSystem.Application.Generic;
using BillingSystem.Domain.Entities.ApartmentEntity;
using BillingSystem.Schema.Apartment;

namespace BillingSystem.Application;

public interface IApartmentService : IGenericService<Apartment, ApartmentRequest, ApartmentResponse>
{
}
