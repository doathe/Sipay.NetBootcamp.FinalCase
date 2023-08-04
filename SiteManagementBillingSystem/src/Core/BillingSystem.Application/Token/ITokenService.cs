using BillingSystem.Application.Common;
using BillingSystem.Schema.Token;

namespace BillingSystem.Application.Token;

public interface ITokenService
{
    public ResponseModel<TokenResponse> Login(TokenRequest request);
}