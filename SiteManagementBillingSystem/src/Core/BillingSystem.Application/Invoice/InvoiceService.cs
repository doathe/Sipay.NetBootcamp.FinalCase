using AutoMapper;
using BillingSystem.Domain;
using BillingSystem.Infrastructure.EFCore;
using BillingSystem.Schema;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Application;

public class InvoiceService : IInvoiceService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly BillingSystemDbContext context;

    public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper, BillingSystemDbContext context)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.context = context;
    }

    public ResponseModel CreateForAll(InvoiceRequest request)
    {
        try
        {
            var apartments = context.Set<Apartment>().ToList();

            foreach (Apartment apartment in apartments)
            {
                var entity = mapper.Map<Invoice>(request);
                entity.ApartmentId = apartment.Id;
                unitOfWork.DynamicRepository<Invoice>().Create(entity);
                unitOfWork.DynamicRepository<Invoice>().Save();
            }

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public ResponseModel CreateForAllByDividing(InvoiceRequest request)
    {
        try
        {
            var apartments = context.Set<Apartment>().ToList();
            request.Amount = request.Amount / apartments.Count();

            foreach (Apartment apartment in apartments)
            {
                var entity = mapper.Map<Invoice>(request);
                entity.ApartmentId = apartment.Id;
                unitOfWork.DynamicRepository<Invoice>().Create(entity);
                unitOfWork.DynamicRepository<Invoice>().Save();
            }

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public ResponseModel CreateById(int id, InvoiceRequest request)
    {
        try
        {
            var entity = mapper.Map<Invoice>(request);
            entity.ApartmentId = id;

            unitOfWork.DynamicRepository<Invoice>().Create(entity);
            unitOfWork.DynamicRepository<Invoice>().Save();

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public ResponseModel<IEnumerable<InvoiceResponse>> GetAll(params string[] includes)
    {
        try
        {
            var entity = unitOfWork.DynamicRepository<Invoice>().GetAllWithInclude(includes).Where(x => x.InvoicePaymentStatus == 0).ToList();
            var mapped = mapper.Map<IEnumerable<InvoiceResponse>>(entity);
            return new ResponseModel<IEnumerable<InvoiceResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<IEnumerable<InvoiceResponse>>(ex.Message);
        }
    }

    public ResponseModel<IEnumerable<InvoiceResponse>> GetByApartment(int id)
    {
        try
        {
            var entity = context.Set<Apartment>().Include(x => x.Invoices).FirstOrDefault(e => e.Id == id);
            var invoicesList = entity.Invoices.ToList();

            var mapped = mapper.Map<IEnumerable<InvoiceResponse>>(invoicesList);
            return new ResponseModel<IEnumerable<InvoiceResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<IEnumerable<InvoiceResponse>>(ex.Message);
        }
    }

    public ResponseModel<IEnumerable<InvoiceResponse>> GetByMonth(string month)
    {
        try
        {
            var entityList = unitOfWork.DynamicRepository<Invoice>().WhereWithInclude(x => x.Month == month, "Apartment").ToList();
            var mapped = mapper.Map<IEnumerable<InvoiceResponse>>(entityList);
            return new ResponseModel<IEnumerable<InvoiceResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<IEnumerable<InvoiceResponse>>(ex.Message);
        }
    }
}
