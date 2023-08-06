using AutoMapper;
using BillingSystem.Domain;
using BillingSystem.Infrastructure.EFCore;
using BillingSystem.Schema;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Application;

public class DuesService : IDuesService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly BillingSystemDbContext context;

    public DuesService(IUnitOfWork unitOfWork, IMapper mapper, BillingSystemDbContext context)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.context = context;
    }

    public ResponseModel CreateForAll(DuesRequest request)
    {
        try
        {
            var apartments = context.Set<Apartment>().ToList();

            foreach(Apartment apartment in apartments)
            {
                var entity = mapper.Map<Dues>(request);
                entity.ApartmentId = apartment.Id;
                unitOfWork.DynamicRepository<Dues>().Create(entity);
                unitOfWork.DynamicRepository<Dues>().Save();
            }

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public ResponseModel CreateById(int id, DuesRequest request)
    {
        try
        {
            var entity = mapper.Map<Dues>(request);
            entity.ApartmentId = id;

            unitOfWork.DynamicRepository<Dues>().Create(entity);
            unitOfWork.DynamicRepository<Dues>().Save();

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public ResponseModel<IEnumerable<DuesResponse>> GetAll(params string[] includes)
    {
        try
        {
            var entity = unitOfWork.DynamicRepository<Dues>().GetAllWithInclude(includes).Where(x => x.DuesPaymentStatus == 0).ToList();
            var mapped = mapper.Map<IEnumerable<DuesResponse>>(entity);
            return new ResponseModel<IEnumerable<DuesResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<IEnumerable<DuesResponse>>(ex.Message);
        }
    }

    public ResponseModel<IEnumerable<DuesResponse>> GetByApartment(int id)
    {
        try
        {
            var entity = context.Set<Apartment>().Include(x => x.Dues).FirstOrDefault(e => e.Id == id);
            var duesList = entity.Dues.ToList();

            var mapped = mapper.Map<IEnumerable<DuesResponse>>(duesList);
            return new ResponseModel<IEnumerable<DuesResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<IEnumerable<DuesResponse>>(ex.Message);
        }
    }

    public ResponseModel<IEnumerable<DuesResponse>> GetByMonth(string month)
    {
        try
        {
            var entityList = unitOfWork.DynamicRepository<Dues>().WhereWithInclude(x => x.Month == month, "Apartment").ToList();
            var mapped = mapper.Map<IEnumerable<DuesResponse>>(entityList);
            return new ResponseModel<IEnumerable<DuesResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<IEnumerable<DuesResponse>>(ex.Message);
        }
    }
}