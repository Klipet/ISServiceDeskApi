namespace ISServiceDeskApi.dtos;

public class CreateTicketDto
{
    public int CompanyId { get; set; }
    public int EmployeeId { get; set; } // Сотрудник компании
    public string Title { get; set; }
    public string Description { get; set; }
    public string UserToken { get; set; }
}
