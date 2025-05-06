namespace ISServiceDeskApi.Responses;

public class CreateUserResponse
{
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string CompanyName { get; set; }
    public string Login { get; set; }
    public string PasswordHesh { get; set; }
}