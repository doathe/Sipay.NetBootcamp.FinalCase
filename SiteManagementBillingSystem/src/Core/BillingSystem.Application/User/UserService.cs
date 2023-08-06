using AutoMapper;
using BillingSystem.Domain;
using BillingSystem.Infrastructure.EFCore;
using BillingSystem.Schema;

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

    public override ResponseModel Create(UserRequest request)
    {
        try
        {
            var entity = mapper.Map<UserRequest, User>(request);
            entity.Password = RandomPasswordGenerator.GenerateRandomPassword();
            unitOfWork.DynamicRepository<User>().Create(entity);
            unitOfWork.DynamicRepository<User>().Save();

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }
    public override ResponseModel Update(int Id, UserRequest request)
    {
        try
        {
            var entity = mapper.Map<UserRequest, User>(request);
            var existingEntity = unitOfWork.DynamicRepository<User>().GetById(Id);
            entity.Id = Id;
            entity.Password = existingEntity.Password;

            unitOfWork.DynamicRepository<User>().Update(entity);
            unitOfWork.DynamicRepository<User>().Save();

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }
}