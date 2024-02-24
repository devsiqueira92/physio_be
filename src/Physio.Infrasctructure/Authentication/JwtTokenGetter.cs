//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;

//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Physio.Infrasctructure.Authentication;

//internal sealed class JwtTokenGetter : IJwtTokenGetter
//{
//    private readonly JwtOptions _options;
//    private readonly IHttpContextAccessor _httpContextAccessor;

//    public JwtTokenGetter(IOptions<JwtOptions> options, IHttpContextAccessor httpContextAccessor)
//    {
//        _options = options.Value;
//        _httpContextAccessor = httpContextAccessor;
//    }
//    public string FakeExtractCompanyFromToken()
//    {
//        var companyId = "34591dcb-4f96-4021-8059-2cef87e4d927";
//        return companyId;
//    }
//    public Result<Guid> ExtractTokenInfoFromToken()
//    {
//        string authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

//        if (string.IsNullOrEmpty(authorization))
//            return Result.Failure<Guid>(DomainErrors.Token.EmptyToken);

//        string jwtToken = authorization["Bearer".Length..].Trim();

//        ClaimsPrincipal claims = TokenValidate(jwtToken);
//        var userId = claims.FindFirst("_id").Value;

//        if (string.IsNullOrEmpty(userId))
//            return Result.Failure<Guid>(DomainErrors.Token.InvalidToken);

//        return Guid.Parse(userId);
//    }

//    private ClaimsPrincipal TokenValidate(string token)
//    {
//        var key = new SymmetricSecurityKey(Convert.FromBase64String(_options.SecretKey));
//        var validatorParams = new TokenValidationParameters
//        {
//            IssuerSigningKey = key,
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateIssuerSigningKey = true,
//            RequireExpirationTime = true,
//            ValidIssuer = _options.Issuer,
//            ValidAudience = _options.Audience,

//        };

//        var tokenHandler = new JwtSecurityTokenHandler();
//        return tokenHandler.ValidateToken(token, validatorParams, out _);
//    }

//}
