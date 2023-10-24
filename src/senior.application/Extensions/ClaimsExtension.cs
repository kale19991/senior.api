using senior.domain.Entites;
using System.Security.Claims;

namespace senior.application.Extensions;

public static class ClaimsExtension
{
    public static ClaimsIdentity GenerateClaims(this User user)
    {
        var claimsIdentity = new ClaimsIdentity();

        claimsIdentity.AddClaim(new Claim("Id", user.Id.ToString()));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Email.Value));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email.Value));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));

        return claimsIdentity;
    }
}
