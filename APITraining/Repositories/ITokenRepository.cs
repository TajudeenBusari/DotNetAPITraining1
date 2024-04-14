using Microsoft.AspNetCore.Identity;

namespace APITraining.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
