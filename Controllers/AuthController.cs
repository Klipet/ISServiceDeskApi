using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DevExpress.Xpo;
using ISServiceDeskApi.Entities;
using ISServiceDeskApi.Requests;
using ISServiceDeskApi.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ISServiceDeskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UnitOfWork uow, IConfiguration config) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] CreateAuthRequest request)
    {
        var user = uow.Query<UserEntity>().FirstOrDefault(u => u.Login == request.Login);

        var passwordMatch = BCrypt.Net.BCrypt.Verify(request.Password, user?.PasswordHesh);
        if (!passwordMatch)
        {
            return Unauthorized("Неверный логин или пароль");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );
        var response = new AuthenticationResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };

        return Ok(response);
    }
}