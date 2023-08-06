using AutoMapper;
using BillingSystem.Domain;
using BillingSystem.Infrastructure.EFCore;
using BillingSystem.Schema;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Application;

internal class PaymentService : IPaymentService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly BillingSystemDbContext context;

    public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, BillingSystemDbContext context)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.context = context;
    }

    public ResponseModel CreateDuesPayment(int DuesId, int UserId)
    {
        try
        {
            var Dues = context.Set<Dues>().FirstOrDefault(x => x.Id == DuesId);
            var amount = Dues.Amount;
            Dues.DuesPaymentStatus = 1;
            Payment payment = new Payment
            {
                PaymentType = 1,
                Amount = amount,
                UserId = UserId,
                DuesId = DuesId,
            };

            context.Set<Payment>().Add(payment);
            context.SaveChanges();

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public ResponseModel CreateInvoicePayment(int InvoiceId, int UserId)
    {
        try
        {
            var Invoice = context.Set<Invoice>().FirstOrDefault(x => x.Id == InvoiceId);
            var amount = Invoice.Amount;
            Invoice.InvoicePaymentStatus = 1;
            Payment payment = new Payment
            {
                PaymentType = 2,
                Amount = amount,
                UserId = UserId,
                InvoiceId = InvoiceId,
            };

            context.Set<Payment>().Add(payment);
            context.SaveChanges();

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public ResponseModel<IEnumerable<BasePaymentResponse>> GetAll(params string[] includes)
    {
        try
        {
            var entityList = context.Set<Payment>().Include(x => x.User).ToList();
            var mapped = mapper.Map<IEnumerable<BasePaymentResponse>>(entityList);
            return new ResponseModel<IEnumerable<BasePaymentResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<IEnumerable<BasePaymentResponse>>(ex.Message);
        }
    }
}
