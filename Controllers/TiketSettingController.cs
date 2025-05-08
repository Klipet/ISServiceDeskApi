using DevExpress.Xpo;
using ISServiceDeskApi.dtos;
using ISServiceDeskApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISServiceDeskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiketSettingController : ControllerBase
{
    private readonly UnitOfWork _uow;
    public TiketSettingController(UnitOfWork uow)
    {
        _uow = uow;
    }
    [HttpPost("create-mod")]
    public IActionResult CreateModTiket([FromBody] CreateTiketModeDto model) 
    {
        var mod = new TiketModeEntites(_uow)
        {
            Name = model.Name
        };
        _uow.CommitChanges();
        return Ok(new {message = "Успешно создан" });
    }
    [HttpPost("create-type")]
    public IActionResult CreateTypeTiket([FromBody] CreateTiketTypeDto model) 
    {
        var mod = new TiketTypeEntites(_uow)
        {
            Name = model.Name
        };
        _uow.CommitChanges();
        return Ok(new { message = "Успешно создан" });
    }
    [HttpPost("create-priority")]
    public IActionResult CreatePreorityTiket([FromBody] CreateTiketPreorityDto model) 
    {
        var mod = new TiketPreorityEntites(_uow)
        {
            Name = model.Name
        };
        _uow.CommitChanges();
        return Ok(new { message = "Успешно создан" });
    }

}
