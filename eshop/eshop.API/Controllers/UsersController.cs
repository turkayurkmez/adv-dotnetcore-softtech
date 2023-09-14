using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (userLoginModel.UserName == "turkay" && userLoginModel.Password == "123")
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-bizim-keyimiz"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                    {
                        new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.UniqueName, userLoginModel.UserName),
                        new Claim("role", "admin"),

                    };
                    var token = new JwtSecurityToken(
                        issuer: "softtech.server",
                        audience: "softtech.client",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credential
                        );


                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

                }
            }

            return BadRequest();
        }
    }



    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}

