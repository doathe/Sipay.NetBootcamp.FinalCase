﻿using AutoMapper;
using BillingSystem.Application.Generic;
using BillingSystem.Domain.Entities.ApartmentEntity;
using BillingSystem.Domain.Entities.UserEntity;
using BillingSystem.Infrastructure.EFCore.Uow;
using BillingSystem.Schema.Apartment;
using BillingSystem.Schema.User;

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