using AutoMapper;
using BillingSystem.Application.Common;
using BillingSystem.Domain.SeedWork;
using BillingSystem.Infrastructure.EFCore.Uow;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace BillingSystem.Application.Generic;

public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse> where TEntity : BaseEntity
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public GenericService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public virtual ResponseModel Delete(int Id)
    {
        try
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetById(Id);
            if (entity == null)
            {
                return new ResponseModel("Record not found!");
            }

            unitOfWork.DynamicRepository<TEntity>().DeleteById(Id);
            unitOfWork.Complete();
            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public virtual ResponseModel<IEnumerable<TResponse>> GetAll(params string[] includes)
    {
        try
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetAllWithInclude(includes);
            var mapped = mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entity);
            return new ResponseModel<IEnumerable<TResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<IEnumerable<TResponse>>(ex.Message);
        }
    }

    public virtual ResponseModel<TResponse> GetById(int id, params string[] includes)
    {
        try
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetByIdWithInclude(id, includes);
            var mapped = mapper.Map<TEntity, TResponse>(entity);
            return new ResponseModel<TResponse>(mapped);
        }
        catch (Exception ex)
        {
            return new ResponseModel<TResponse>(ex.Message);
        }
    }

    public virtual ResponseModel Create(TRequest request)
    {
        try
        {
            var entity = mapper.Map<TRequest, TEntity>(request);

            unitOfWork.DynamicRepository<TEntity>().Create(entity);
            unitOfWork.DynamicRepository<TEntity>().Save();

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }

    public virtual ResponseModel Update(int Id, TRequest request)
    {
        try
        {
            //var exist = unitOfWork.DynamicRepository<TEntity>().GetById(Id);
            //if (exist == null)
            //{
            //    return new ResponseModel("Record not found!");
            //}

            var entity = mapper.Map<TRequest, TEntity>(request);
            entity.Id = Id;
            entity.UpdatedDate = DateTime.UtcNow;
            unitOfWork.DynamicRepository<TEntity>().Update(entity);
            unitOfWork.DynamicRepository<TEntity>().Save();

            return new ResponseModel();
        }
        catch (Exception ex)
        {
            return new ResponseModel(ex.Message);
        }
    }
}