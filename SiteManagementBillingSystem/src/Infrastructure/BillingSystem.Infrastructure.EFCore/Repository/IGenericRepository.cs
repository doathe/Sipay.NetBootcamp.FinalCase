using BillingSystem.Domain;
using System.Linq.Expressions;

namespace BillingSystem.Infrastructure.EFCore;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    public void Save();
    public TEntity GetById(int id);
    public TEntity GetByIdWithInclude(int id, params string[] includes);
    public void Create(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public void DeleteById(int id);
    public IEnumerable<TEntity> GetAll();
    public IEnumerable<TEntity> GetAllWithInclude(params string[] includes);
    public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
    public IEnumerable<TEntity> WhereWithInclude(Expression<Func<TEntity, bool>> expression, params string[] includes);
    public IQueryable<TEntity> GetAllAsQueryable();
}
