using System.Text.Json.Serialization;

namespace BillingSystem.PaymentAPI;

public class PaymentResponse
{
    [JsonPropertyName("Success")]
    public bool Success { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; }
}