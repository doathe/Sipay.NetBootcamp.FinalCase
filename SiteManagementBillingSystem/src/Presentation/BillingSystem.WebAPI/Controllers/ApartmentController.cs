﻿using BillingSystem.Application.Common;
using BillingSystem.Application;
using BillingSystem.Schema.User;
using Microsoft.AspNetCore.Mvc;
using BillingSystem.Schema.Apartment;

namespace BillingSystem.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentService service;
    public ApartmentController(IApartmentService service)
    {
        this.service = service;
    }


    [HttpGet]
    public ResponseModel<IEnumerable<ApartmentResponse>> GetAll()
    {
        var response = service.GetAll();
        return response;
    }

    [HttpGet("{id}")]
    public ResponseModel<ApartmentResponse> Get(int id)
    {
        var response = service.GetById(id);
        return response;
    }


    [HttpPost]
    public ResponseModel Post([FromBody] ApartmentRequest request)
    {
        var response = service.Create(request);
        return response;
    }

    [HttpPut("{id}")]
    public ResponseModel Put(int id, [FromBody] ApartmentRequest request)
    {

        var response = service.Update(id, request);
        return response;
    }


    [HttpDelete("{id}")]
    public ResponseModel Delete(int id)
    {
        var response = service.Delete(id);
        return response;
    }
}
