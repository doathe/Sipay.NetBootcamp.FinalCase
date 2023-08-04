using AutoMapper;
using BillingSystem.Application.Generic;
using BillingSystem.Domain.Entities.UserEntity;
using BillingSystem.Infrastructure.EFCore.Uow;
using BillingSystem.Schema.User;

namespace BillingSystem.Application;

public class UserService : GenericService<User, UserRequest, UserResponse>, IUserService
{

    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
}