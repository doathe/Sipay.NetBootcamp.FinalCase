using BillingSystem.Domain.SeedWork;
using BillingSystem.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace BillingSystem.Infrastructure.EFCore.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly BillingSystemDbContext context;
    public GenericRepository(BillingSystemDbContext context)
    {
        this.context = context;
    }

    public void Save()
    {
        context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entity = context.Set<TEntity>().Find(id);
        Delete(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return context.Set<TEntity>().AsNoTracking().ToList();
    }

    public IQueryable<TEntity> GetAllAsQueryable()
    {
        return context.Set<TEntity>().AsQueryable();
    }

    public TEntity GetById(int id)
    {
        var entity = context.Set<TEntity>().Find(id);
        return entity;
    }

    public void Create(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.UpdatedDate = DateTime.UtcNow;
        context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        //context.Set<TEntity>().Update(entity);
        var existingEntity = context.Set<TEntity>().Find(entity.Id);

        if (existingEntity != null)
        {
            context.Entry(existingEntity).CurrentValues.SetValues(entity);
            Save();
        }
    }

    public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
    {
        return context.Set<TEntity>().Where(expression).AsQueryable();
    }

    public TEntity GetByIdWithInclude(int id, params string[] includes)
    {
        var query = context.Set<TEntity>().AsQueryable();
        query = includes.Aggregate(query, (currenct, inc) => currenct.Include(inc));
        return query.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<TEntity> GetAllWithInclude(params string[] includes)
    {
        var query = context.Set<TEntity>().AsQueryable();
        query = includes.Aggregate(query, (currenct, inc) => currenct.Include(inc));
        return query.ToList();
    }

    public IEnumerable<TEntity> WhereWithInclude(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        var query = context.Set<TEntity>().AsQueryable();
        query.Where(expression);
        query = includes.Aggregate(query, (currenct, inc) => currenct.Include(inc));
        return query.ToList();
    }
}