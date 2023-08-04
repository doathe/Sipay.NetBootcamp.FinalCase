using BillingSystem.Application.Common;
using BillingSystem.Domain.Entities.UserEntity;
using BillingSystem.Infrastructure.EFCore.Uow;
using BillingSystem.Schema.Token;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BillingSystem.Application.Token;

public class TokenService : ITokenService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly JwtConfig jwtConfig;

    public TokenService(IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> jwtConfig)
    {
        this.unitOfWork = unitOfWork;
        this.jwtConfig = jwtConfig.CurrentValue;
    }

    public ResponseModel<TokenResponse> Login(TokenRequest request)
    {
        if (request is null)
        {
            return new ResponseModel<TokenResponse>("Request was null");
        }
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return new ResponseModel<TokenResponse>("Request was null");
        }

        request.Email = request.Email.Trim().ToLower();
        request.Password = request.Password.Trim();

        var user = unitOfWork.UserRepository.Where(x => x.Email.Equals(request.Email)).FirstOrDefault();
        if (user is null)
        {
            return new ResponseModel<TokenResponse>("Invalid user informations");
        }
        if (user.Password.ToLower() != CreateMD5(request.Password))
        {
            return new ResponseModel<TokenResponse>("Invalid user informations");
        }

        string token = Token(user);

        TokenResponse response = new()
        {
            AccessToken = token,
            ExpireTime = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            Email = user.Email
        };

        return new ResponseModel<TokenResponse>(response);
    }

    private string Token(User user)
    {
        Claim[] claims = GetClaims(user);
        var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

        var jwtToken = new JwtSecurityToken(
            jwtConfig.Issuer,
            jwtConfig.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return accessToken;
    }


    private Claim[] GetClaims(User user)
    {
        var claims = new[]
        {
            new Claim("Email",user.Email),
            new Claim("UserId",user.Id.ToString()),
            new Claim("Role",user.Role),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}")
        };

        return claims;
    }

    private string CreateMD5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();

        }
    }
}
