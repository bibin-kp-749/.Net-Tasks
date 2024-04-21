using JWT_Based_Authentication.Model;
using JWT_Based_Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Based_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private IConfiguration configuration;
        public Auth(IConfiguration configuration) { 
            this.configuration = configuration;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(Login user)
        {
            IActionResult response = Unauthorized();
            if (user != null)
            {
                var validUser=UserServices.users.FirstOrDefault(x=>x.UserName==user.Username&& x.Password==user.Password); 
                if (validUser!=null)
                {
                    var issuer = configuration["Jwt:Issuer"];
                    var audience = configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                                            new SymmetricSecurityKey(key),
                                            SecurityAlgorithms.HmacSha512Signature
                                        );
                    var subject = new ClaimsIdentity(new[]
                      {
                        new Claim(ClaimTypes.NameIdentifier,validUser.UserName),
                        new Claim(ClaimTypes.Role,validUser.Role),
                       });
                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);
                    return Ok(jwtToken);
                }
            }
            return response;
        }
    }
}
