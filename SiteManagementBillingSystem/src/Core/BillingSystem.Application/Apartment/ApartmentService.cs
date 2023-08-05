using AutoMapper;
using BillingSystem.Infrastructure.EFCore;
using BillingSystem.Schema;
using BillingSystem.Domain;

namespace BillingSystem.Application;

public class ApartmentService : GenericService<Apartment, ApartmentRequest, ApartmentResponse>, IApartmentService
{

    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public ApartmentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
}