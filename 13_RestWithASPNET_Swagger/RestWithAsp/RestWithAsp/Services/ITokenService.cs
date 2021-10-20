using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithAsp.Services
{
    public interface ITokenService
    {
        string GenerateAcessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
