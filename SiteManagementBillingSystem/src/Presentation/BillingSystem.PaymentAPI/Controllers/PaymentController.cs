using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.PaymentAPI;

[Route("api/[controller]s")]
[ApiController]
public class PaymentController : ControllerBase
{
    [HttpPost]
    public IActionResult MakePayment([FromBody] PaymentRequest paymentRequest)
    {
        return Ok(new PaymentResponse
        {
            Success = true,
            Message = "Ödeme işlemi başarıyla gerçekleştirildi."
        });
    }
}
