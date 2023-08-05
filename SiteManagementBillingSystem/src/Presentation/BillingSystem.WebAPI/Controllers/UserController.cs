using BillingSystem.Application;
using BillingSystem.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.WebAPI;

[Authorize(Roles = "Admin")]
[Route("api/[controller]s")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService service;
    public UserController(IUserService service)
    {
        this.service = service;
    }


    [HttpGet]
    public ResponseModel<IEnumerable<UserResponse>> GetAll()
    {
        var response = service.GetAll("Apartment");
        return response;
    }

    [HttpGet("{id}")]
    public ResponseModel<UserResponse> Get(int id)
    {
        var response = service.GetById(id,"Apartment");
        return response;
    }


    [HttpPost]
    public ResponseModel Post([FromBody] UserRequest request)
    {
        var response = service.Create(request);
        return response;
    }

    [HttpPut("{id}")]
    public ResponseModel Put(int id, [FromBody] UserRequest request)
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
