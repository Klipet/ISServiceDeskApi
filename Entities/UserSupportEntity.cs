using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities;

[Persistent("UserSupport")]
public class UserSupportEntity(Session session) : XPLiteObject(session)
{
    [Key(true)] public int ID { get; set; }

    [Association("Ticket-UserSupport")] public TicketEntity Ticket { get; set; }

    [Association("User-UserSupport")] public UserEntity User { get; set; }

    public string Comment { get; set; }
}