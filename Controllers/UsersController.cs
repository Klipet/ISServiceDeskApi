using DevExpress.Xpo;
using ISServiceDeskApi.DTO;
using ISServiceDeskApi.ModelDB;
using Microsoft.AspNetCore.Mvc;


namespace ISServiceDeskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UnitOfWork _uow;

    public UsersController(UnitOfWork uow)
    {
        _uow = uow;
    }

    // Создание пользователя и привязка его к компании
    [HttpPost("create")]
    public IActionResult CreateUser([FromBody] CreateUserDto request)
    {
        // Ищем компанию по ID
        var company = _uow.GetObjectByKey<Company>(request.CompanyId);
        if (company == null)
            return NotFound("Компания не найдена");

        // Создаём пользователя
        var user = new UserEntity(_uow)
        {
            UserName = request.Name,
            Status = request.Status,
            Phone = request.Phone,
            Login = request.Login,
            PasswordHesh = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Company = company
        };

        // Сохраняем изменения в базе данных
        _uow.CommitChanges();

        return Ok(new { user.UserName, user.Phone, Company = company.Name, user.Login, user.PasswordHesh});
    }
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _uow.Query<UserEntity>()
            .Select(u => new
            {
                u.ID,
                u.UserName,
                u.Phone,
                u.Status,
                Company = u.Company != null ? new
                {
                    u.Company.ID,
                    u.Company.Name
                } : null
            })
            .ToList();

        return Ok(users);
    }
}