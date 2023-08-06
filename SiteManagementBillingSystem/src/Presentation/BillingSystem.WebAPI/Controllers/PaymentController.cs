using System.Net.Http.Headers;
using System.Text.Json;
using BillingSystem.Application;
using BillingSystem.Schema;
using BillingSystem.PaymentAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BillingSystem.WebAPI;

[Route("api/[controller]s")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly JwtHelper _jwtHelper;
    private readonly IPaymentService service;

    public PaymentController(IHttpClientFactory httpClientFactory, JwtHelper jwtHelper, IPaymentService service)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5281");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _jwtHelper = jwtHelper;
        this.service = service;
    }

    [Authorize(Roles = "User")]
    [HttpPost("invoice/{InvoiceId}")]
    public async Task<IActionResult> MakeInvoicePayment([FromBody] BasePaymentRequest request, int InvoiceId)
    {
        string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        int userId = (int)_jwtHelper.GetUserIdFromToken(token);

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/payments", request);

        if (response.IsSuccessStatusCode)
        {
            service.CreateInvoicePayment(InvoiceId, userId);
            var responseContent = await response.Content.ReadAsStringAsync();
            var paymentResponse = JsonSerializer.Deserialize<PaymentResponse>(responseContent);
            return Ok(paymentResponse);
        }
        else
        {
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }

    [Authorize(Roles = "User")]
    [HttpPost("dues/{DuesId}")]
    public async Task<IActionResult> MakeDuesPayment([FromBody] BasePaymentRequest request, int DuesId)
    {
        string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        int userId = (int)_jwtHelper.GetUserIdFromToken(token);

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/payments", request);

        if (response.IsSuccessStatusCode)
        {
            service.CreateDuesPayment(DuesId, userId);
            var responseContent = await response.Content.ReadAsStringAsync();
            var paymentResponse = JsonSerializer.Deserialize<PaymentResponse>(responseContent);
            ResponseModel responseM = new ResponseModel
            {
                Message = paymentResponse.Message,
                Success = paymentResponse.Success,
            };
            return Ok(responseM);
        }
        else
        {
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ResponseModel<IEnumerable<BasePaymentResponse>> GetAll()
    {
        var response = service.GetAll();
        return response;
    }
}
