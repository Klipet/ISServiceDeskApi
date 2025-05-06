namespace ISServiceDeskApi.Requests;

public class CreateUserRequest
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public string Phone { get; set; }
    public int CompanyId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}