using D8M7Q2_SportEvents.Entities.Dto.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace D8M7Q2_SportEvents.Endpoint.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task Register(UserInputDto dto)
        {
            var user = new IdentityUser(dto.UserName);
            await userManager.CreateAsync(user, dto.Password);
        }

        [HttpPost("login")]
        public async Task Login(UserInputDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                throw new ArgumentException("User not found!");
            }
            else
            {
                var result = await userManager.CheckPasswordAsync(user, dto.Password);
                if (!result)
                {
                    throw new ArgumentException("Incorrect password!");
                }
                else
                {
                    var claim = new List<Claim>();
                    claim.Add(new Claim(ClaimTypes.Name, user.UserName!));
                    claim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

                    var token = GenerateAccessToken(claim);
                }
            }
        }

        private JwtSecurityToken GenerateAccessToken(IEnumerable<Claim>? claims)
        {
            var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes("Nagyonhosszútitkosítókulcs"));

            int expiryInMinutes = 24 * 60;

            return new JwtSecurityToken(
                  issuer: "sportevent.com",
                  audience: "sportevent.com",
                  claims: claims?.ToArray(),
                  expires: DateTime.Now.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
        }
    }
}
