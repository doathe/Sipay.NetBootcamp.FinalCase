using BillingSystem.Application;
using BillingSystem.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService service;
    public InvoiceController(IInvoiceService service)
    {
        this.service = service;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ResponseModel<IEnumerable<InvoiceResponse>> GetAll()
    {
        var response = service.GetAll("Apartment");
        return response;
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("{apartmentId}")]
    public ResponseModel<IEnumerable<InvoiceResponse>> Get(int apartmentId)
    {
        var response = service.GetByApartment(apartmentId);
        return response;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("CreateForAll")]
    public ResponseModel Post([FromBody] InvoiceRequest request)
    {
        var response = service.CreateForAll(request);
        return response;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("CreateForAllByDividing")]
    public ResponseModel PostByDividing([FromBody] InvoiceRequest request)
    {
        var response = service.CreateForAllByDividing(request);
        return response;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("{apartmentId}")]
    public ResponseModel Post(int apartmentId, [FromBody] InvoiceRequest request)
    {
        var response = service.CreateById(apartmentId, request);
        return response;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetByMonth")]
    public ResponseModel<IEnumerable<InvoiceResponse>> GetByMonth([FromQuery] string month)
    {
        var response = service.GetByMonth(month);
        return response;
    }
}
