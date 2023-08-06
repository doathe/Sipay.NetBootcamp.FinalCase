using BillingSystem.Schema;

namespace BillingSystem.Application;

public interface IDuesService
{
    public ResponseModel CreateById(int id, DuesRequest request);
    public ResponseModel CreateForAll(DuesRequest request);
    public ResponseModel<IEnumerable<DuesResponse>> GetAll(params string[] includes);
    public ResponseModel<IEnumerable<DuesResponse>> GetByApartment(int id);
    public ResponseModel<IEnumerable<DuesResponse>> GetByMonth(string month);
}