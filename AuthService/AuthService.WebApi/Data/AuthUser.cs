using Microsoft.AspNetCore.Identity;

namespace AuthService.WebApi.Data
{
    public class AuthUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
