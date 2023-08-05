using BillingSystem.Schema;

namespace BillingSystem.Application;

public interface ITokenService
{
    public ResponseModel<TokenResponse> Login(TokenRequest request);
}