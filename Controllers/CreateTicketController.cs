using DevExpress.Xpo;
using ISServiceDeskApi.dtos;
using ISServiceDeskApi.ModelDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ISServiceDeskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly UnitOfWork _uow;

        public TicketController(UnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("create")]
        [Authorize]
        public IActionResult CreateTicket([FromBody] CreateTicketDto dto)
        {
            // Получаем ID текущего пользователя из JWT-токена
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Пользователь не авторизован");

            int currentUserId = int.Parse(userIdClaim.Value);
            var currentUser = _uow.GetObjectByKey<UserEntites>(currentUserId);
            var status = _uow.GetObjectByKey<StatusEntites>(currentUserId);

            if (currentUser == null)
                return Unauthorized("Пользователь не найден");

            // Получаем компанию и сотрудника
            var company = _uow.GetObjectByKey<Company>(dto.CompanyId);
            var employee = _uow.GetObjectByKey<UserEntites>(dto.EmployeeId);

            if (company == null)
                return BadRequest("Компания не найдена");

            if (employee == null)
                return BadRequest("Сотрудник не найден");

            if (employee.Company?.ID != company.ID)
                return BadRequest("Сотрудник не принадлежит указанной компании");

            // Проверка: если текущий пользователь не UserSupport (админ/поддержка), 
            // то он сам должен быть сотрудником этой компании
            if (!currentUser.IsSupport && currentUser.Company?.ID != company.ID)
            {
                return Unauthorized("Вы не можете создавать тикеты для другой компании");
            }

            // Создание тикета
            var ticket = new TicketEntites(_uow)
            {
                Title = dto.Title,
                Description = dto.Description,
                Company = company,
                Creator = employee,    // автор — тот, кто создал
                Status = status // поддержка — выбранный сотрудник
            };

            _uow.CommitChanges();

            return Ok(new
            {
                message = "Тикет успешно создан",
                ticketId = ticket.ID
            });
        }
    }
}
