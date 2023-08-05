using BillingSystem.Application;
using BillingSystem.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.WebAPI
{
    [Route("api/[controller]s")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService service;

        public TokenController(ITokenService service)
        {
            this.service = service;
        }

        [HttpPost("Login")]
        public ResponseModel<TokenResponse> Post([FromBody] TokenRequest request)
        {
            var response = service.Login(request);
            return response;
        }
    }
}
