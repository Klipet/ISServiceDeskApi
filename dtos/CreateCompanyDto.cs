namespace ISServiceDeskApi.DTO;

public class CreateCompanyDto
{
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Logo { get; set; }
    public string IDNO { get; set; }
    public bool Status { get; set; }
}
