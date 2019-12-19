using AuthService.WebApi.Data;

namespace AuthService.WebApi.Models
{
    public class UserResponse
    {
        public string UserId { get; }

        public string Name { get; }

        public string Email { get; }

        public UserResponse(AuthUser user)
        {
            UserId = user.Id;

            Name = user.Name;

            Email = user.Email;
        }
    }
}
