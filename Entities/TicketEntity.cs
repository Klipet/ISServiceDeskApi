using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities;

[Persistent("Tickets")]
public class TicketEntity(Session session) : XPLiteObject(session)
{
    [Key(true)] public int Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedData { get; set; }
    public DateTime UpdateData { get; set; }
    public DateTime ClosedData { get; set; }

    [Association("Ticket-UserSupport")]
    public XPCollection<UserSupportEntity> Supports => GetCollection<UserSupportEntity>(nameof(Supports));

    [Association("User-Tickets")] public UserEntity Creator { get; set; }
    [Association("Company-Tickets")] public CompanyEntity Company { get; set; }
    [Association("Status-Tickets")] public StatusEntity Status { get; set; }
}