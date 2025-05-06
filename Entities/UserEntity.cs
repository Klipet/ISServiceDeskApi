using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities;

[Persistent("Users")]
public class UserEntity(Session session) : XPLiteObject(session)
{
    [Key(true)] public int Id { get; set; }
    public string UserName { get; set; }
    public bool Status { get; set; }
    public string Phone { get; set; }
    public string Login { get; set; }
    public string PasswordHesh { get; set; }
    
    [Association("Company-Users")] public CompanyEntity Company { get; set; }

    [Association("User-Tickets")]
    public XPCollection<TicketEntity> Tickets => GetCollection<TicketEntity>(nameof(Tickets));
}