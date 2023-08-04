using BillingSystem.Application.Generic;
using BillingSystem.Schema.User;
using BillingSystem.Domain.Entities.UserEntity;

namespace BillingSystem.Application;

public interface IUserService : IGenericService<User, UserRequest, UserResponse>
{
}
