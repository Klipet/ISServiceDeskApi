namespace ISServiceDeskApi.Requests;

public class CreateCompanyRequest
{
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Logo { get; set; }
    public string IDNO { get; set; }
    public bool Status { get; set; }
}