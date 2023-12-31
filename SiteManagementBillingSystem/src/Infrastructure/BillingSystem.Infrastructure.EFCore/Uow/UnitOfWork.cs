﻿using BillingSystem.Domain;

namespace BillingSystem.Infrastructure.EFCore;
public class UnitOfWork : IUnitOfWork
{

    private readonly BillingSystemDbContext context;
    public UnitOfWork(BillingSystemDbContext context)
    {
        this.context = context;

        UserRepository = new GenericRepository<User>(context);
        ApartmentRepository = new GenericRepository<Apartment>(context);
        DuesRepository = new GenericRepository<Dues>(context);
        InvoiceRepository = new GenericRepository<Invoice>(context);
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
    public IGenericRepository<Dues> DuesRepository { get; private set; }
    public IGenericRepository<Invoice> InvoiceRepository { get; private set; }
}

