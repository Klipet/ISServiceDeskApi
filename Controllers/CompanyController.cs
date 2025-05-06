﻿using DevExpress.Xpo;
using ISServiceDeskApi.Entities;
using ISServiceDeskApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ISServiceDeskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly UnitOfWork _uow;

        public CompanyController(UnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("create")]
        public IActionResult CreateCompany([FromBody] CreateCompanyRequest request)
        {
            // Проверка на дубликат по IDNO (по желанию)
            var existing = _uow.Query<CompanyEntity>().FirstOrDefault(c => c.IDNO == request.IDNO);
            if (existing != null)
                return Conflict("Компания с таким IDNO уже существует");

            var company = new CompanyEntity(_uow)
            {
                Name = request.Name,
                Mail = request.Mail,
                Logo = request.Logo,
                IDNO = request.IDNO,
                Status = request.Status
            };

            _uow.CommitChanges();

            return Ok(new
            {
                company.Name,
                company.Mail,
                company.IDNO
            });
        }
        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var companies = _uow.Query<CompanyEntity>()
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Mail,
                    c.IDNO,
                    c.Status
                })
                .ToList();

            return Ok(companies);
        }
        [HttpGet("{id}")]
        public IActionResult GetUsersByCompanyId(int id)
        {
            var company = _uow.GetObjectByKey<CompanyEntity>(id);
            if (company == null)
                return NotFound("Компания не найдена");

            var users = company.Users
                .Select(u => new
                {
                    u.Id,
                    u.UserName,
                    u.Phone,
                    u.Status
                })
                .ToList();

            return Ok(users);
        }
    }
}
