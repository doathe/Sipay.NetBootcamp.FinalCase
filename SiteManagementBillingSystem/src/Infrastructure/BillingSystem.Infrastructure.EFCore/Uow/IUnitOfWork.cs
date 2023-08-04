using BillingSystem.Domain.Entities.ApartmentEntity;
using BillingSystem.Domain.Entities.UserEntity;
using BillingSystem.Domain.SeedWork;
using BillingSystem.Infrastructure.EFCore.Repository;

namespace BillingSystem.Infrastructure.EFCore.Uow;

public interface IUnitOfWork
{
    void Complete();

    IGenericRepository<TEntity> DynamicRepository<TEntity>() where TEntity : BaseEntity;
    IGenericRepository<User> UserRepository { get; }
    IGenericRepository<Apartment> ApartmentRepository { get; }
}