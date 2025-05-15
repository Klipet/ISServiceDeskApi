using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using ISServiceDeskApi.dtos;
using ISServiceDeskApi.ModelDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ISServiceDeskApi.Controllers;

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
    public IActionResult CreateTicket([FromBody] CreateTicketDto dto)
    {
        var user = _uow.FindObject<UserEntity>(CriteriaOperator.Parse("Token == ?", dto.UserToken));
        var userIdClaim = user;

        if (userIdClaim == null)
            return Unauthorized("Пользователь не авторизован");

      
        var currentUser = _uow.GetObjectByKey<UserEntity>(userIdClaim.ID);
        var status = _uow.GetObjectByKey<StatusEntites>(userIdClaim.ID);

        if (currentUser == null)
            return Unauthorized("Пользователь не найден");

        // Получаем компанию и сотрудника
        var company = _uow.GetObjectByKey<Company>(dto.CompanyId);
        var employee = _uow.GetObjectByKey<UserEntity>(dto.EmployeeId);

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
        var ticket = new TicketEntity(_uow)
        {
            Title = dto.Title,
            Description = dto.Description,
            Company = company,
            Creator = employee,    // автор — тот, кто создал
            Status = status, // поддержка — выбранный сотрудник
            CreatedData = DateTime.UtcNow,
            UpdateData = DateTime.UtcNow,
           
        };

        _uow.CommitChanges();

        return Ok(new
        {
            message = "Тикет успешно создан",
            ticketId = ticket.ID
        });
    }
}
