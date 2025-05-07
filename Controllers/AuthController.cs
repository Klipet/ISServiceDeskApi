using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ISServiceDeskApi.ModelDB;
using Microsoft.AspNetCore.Identity.Data;
using ISServiceDeskApi.DTO;
using System.IdentityModel.Tokens.Jwt;


namespace ISServiceDeskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UnitOfWork _uow;
    private readonly IConfiguration _config;

    public AuthController(UnitOfWork uow, IConfiguration config)
    {
        _uow = uow;
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] CreateAuthDto request)
    {


        var user = _uow.Query<UserEntites>().FirstOrDefault(u => u.Login == request.Login);

        if (user == null)
        {
            return Unauthorized("Неверный логин или пароль");
        }

        bool passwordMatch = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHesh);
        if (!passwordMatch)
        {
            return Unauthorized("Неверный логин или пароль");
        }


        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
        new Claim(ClaimTypes.Name, user.UserName)
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );
        // Генерация короткого токена
        var shortToken = Guid.NewGuid().ToString("N");
        user.Token = shortToken;
        user.Save();
        _uow.CommitChanges();
        

        return Ok(new
        {
            token = user.Token
        });
    }
}