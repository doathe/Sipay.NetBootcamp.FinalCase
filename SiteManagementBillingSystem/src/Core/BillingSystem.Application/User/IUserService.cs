using BillingSystem.Application;
using BillingSystem.Schema;
using BillingSystem.Domain;

namespace BillingSystem.Application;

public interface IUserService : IGenericService<User, UserRequest, UserResponse>
{
}
