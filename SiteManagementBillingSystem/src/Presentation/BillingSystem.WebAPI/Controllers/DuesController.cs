using BillingSystem.Application;
using BillingSystem.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.WebAPI;

[Route("api/[controller]s")]
[ApiController]
public class DuesController : ControllerBase
{
    private readonly IDuesService service;
    public DuesController(IDuesService service)
    {
        this.service = service;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ResponseModel<IEnumerable<DuesResponse>> GetAll()
    {
        var response = service.GetAll("Apartment");
        return response;
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("{apartmentId}")]
    public ResponseModel<IEnumerable<DuesResponse>> Get(int apartmentId)
    {
        var response = service.GetByApartment(apartmentId);
        return response;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("CreateForAll")]
    public ResponseModel Post([FromBody] DuesRequest request)
    {
        var response = service.CreateForAll(request);
        return response;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("{apartmentId}")]
    public ResponseModel Post(int apartmentId, [FromBody] DuesRequest request)
    {
        var response = service.CreateById(apartmentId, request);
        return response;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetByMonth")]
    public ResponseModel<IEnumerable<DuesResponse>> GetByMonth([FromQuery] string month)
    {
        var response = service.GetByMonth(month);
        return response;
    }
}
