using BillingSystem.Schema;

namespace BillingSystem.Application;

public interface IPaymentService
{
    public ResponseModel CreateInvoicePayment(int InvoiceId, int UserId);
    public ResponseModel CreateDuesPayment(int DuesId, int UserId);
    public ResponseModel<IEnumerable<BasePaymentResponse>> GetAll(params string[] includes);
}
