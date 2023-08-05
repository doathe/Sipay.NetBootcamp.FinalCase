namespace BillingSystem.Application;

public interface IGenericService<TEntity, TRequest, TResponse>
{
    public ResponseModel<IEnumerable<TResponse>> GetAll(params string[] includes);
    public ResponseModel<TResponse> GetById(int id, params string[] includes);
    public ResponseModel Create(TRequest request);
    public ResponseModel Update(int Id, TRequest request);
    public ResponseModel Delete(int Id);
}