using BillingSystem.Domain;

namespace BillingSystem.Infrastructure.EFCore;

public interface IUnitOfWork
{
    void Complete();

    IGenericRepository<TEntity> DynamicRepository<TEntity>() where TEntity : BaseEntity;
    IGenericRepository<User> UserRepository { get; }
    IGenericRepository<Apartment> ApartmentRepository { get; }
}