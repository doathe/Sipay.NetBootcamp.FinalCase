using BillingSystem.Domain.Entities.ApartmentEntity;
using BillingSystem.Domain.Entities.UserEntity;
using BillingSystem.Domain.SeedWork;
using BillingSystem.Infrastructure.EFCore.Context;
using BillingSystem.Infrastructure.EFCore.Repository;

namespace BillingSystem.Infrastructure.EFCore.Uow;
public class UnitOfWork : IUnitOfWork
{


    private readonly BillingSystemDbContext context;
    public UnitOfWork(BillingSystemDbContext context)
    {
        this.context = context;

        UserRepository = new GenericRepository<User>(context);
        ApartmentRepository = new GenericRepository<Apartment>(context);
    }

    public void Complete()
    {
        context.SaveChanges();
    }

    public IGenericRepository<TEntity> DynamicRepository<TEntity>() where TEntity : BaseEntity
    {
        return new GenericRepository<TEntity>(context);
    }

    public IGenericRepository<User> UserRepository { get; private set; }
    public IGenericRepository<Apartment> ApartmentRepository { get; private set; }
}

