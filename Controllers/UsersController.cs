using DevExpress.Xpo;
using ISServiceDeskApi.dtos;
using ISServiceDeskApi.Entities;
using ISServiceDeskApi.Requests;
using ISServiceDeskApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ISServiceDeskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(UnitOfWork uow) : ControllerBase
    {
        // Создание пользователя и привязка его к компании
        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            // Ищем компанию по ID
            var company = uow.GetObjectByKey<CompanyEntity>(request.CompanyId);
            if (company == null)
                return NotFound("Компания не найдена");

            // Создаём пользователя
            var user = new UserEntity(uow)
            {
                UserName = request.Name,
                Status = request.Status,
                Phone = request.Phone,
                Login = request.Login,
                PasswordHesh = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Company = company
            };

            // Сохраняем изменения в базе данных
            uow.CommitChanges();

            return Ok(
                //это я к примеру, можешь как ниже вытащить в респонсе- и так и так норм в данном случае
                new CreateUserResponse
                {
                    UserName = user.UserName,
                    Phone = user.Phone,
                    CompanyName = company.Name,
                    Login = user.Login,
                    PasswordHesh = user.PasswordHesh
                });
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = uow.Query<UserEntity>()
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Phone = u.Phone,
                    Status = u.Status,
                    Company = new CompanyDto
                    {
                        Id = u.Company.Id,
                        Name = u.Company.Name
                    }
                }).ToList();

            var response = new UsersResponse
            {
                Users = users
            };

            return Ok(response);

            //другой пример - тоже норм когда у тебя мало инфы
            // return Ok(new UsersResponse
            // {
            //     Users = users
            // });
        }
    }
}