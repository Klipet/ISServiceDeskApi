namespace ISServiceDeskApi.dtos;

public sealed class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
    public CompanyDto? Company { get; set; }
}