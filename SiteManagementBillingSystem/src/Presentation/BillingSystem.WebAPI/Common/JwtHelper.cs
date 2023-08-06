using BillingSystem.Application;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BillingSystem.WebAPI;

public class JwtHelper
{
    private readonly JwtConfig _jwtConfig;

    public JwtHelper(IOptionsMonitor<JwtConfig> jwtConfig)
    {
        _jwtConfig = jwtConfig.CurrentValue;
    }

    public int? GetUserIdFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = _jwtConfig.Issuer,
            ValidateAudience = true,
            ValidAudience = _jwtConfig.Audience,
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;

        return string.IsNullOrEmpty(userId) ? null : (int?)int.Parse(userId);
    }
}