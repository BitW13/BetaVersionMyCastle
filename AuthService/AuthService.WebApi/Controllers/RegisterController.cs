using AuthService.WebApi.Data;
using AuthService.WebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthService.WebApi.Controllers
{
    [Route("register")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AuthUser> db;

        public RegisterController(UserManager<AuthUser> db)
        {
            this.db = db;
        }

        [HttpPut]
        public async Task<IActionResult> Register([FromBody]UserRegister registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AuthUser
            {
                Name = registerUser.Name,
                UserName = registerUser.Email,
                Email = registerUser.Email
            };

            var result = await db.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await db.AddClaimAsync(user, new Claim("userName", user.UserName));
            await db.AddClaimAsync(user, new Claim("name", user.Name));
            await db.AddClaimAsync(user, new Claim("userId", user.Id));
            await db.AddClaimAsync(user, new Claim("role", Roles.USER));

            return Ok(new UserResponse(user));
        }
    }
}