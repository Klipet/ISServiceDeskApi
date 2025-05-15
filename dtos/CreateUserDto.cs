namespace ISServiceDeskApi.DTO;

public class CreateUserDto
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public string Phone { get; set; }
    public int CompanyId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
