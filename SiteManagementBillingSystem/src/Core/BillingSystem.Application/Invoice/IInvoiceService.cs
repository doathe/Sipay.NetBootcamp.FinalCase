using BillingSystem.Schema;

namespace BillingSystem.Application;

public interface IInvoiceService
{
    public ResponseModel CreateById(int id, InvoiceRequest request);
    public ResponseModel CreateForAll(InvoiceRequest request);
    public ResponseModel CreateForAllByDividing(InvoiceRequest request);
    public ResponseModel<IEnumerable<InvoiceResponse>> GetAll(params string[] includes);
    public ResponseModel<IEnumerable<InvoiceResponse>> GetByApartment(int id);
    public ResponseModel<IEnumerable<InvoiceResponse>> GetByMonth(string month);
}
