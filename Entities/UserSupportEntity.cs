using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB;

[Persistent("UserSupport")]
public class UserSupportEntity : XPLiteObject
{
    [Key(true)]
    public int ID { get; set; }

    [Association("Ticket-UserSupport")]
    public TicketEntity Ticket { get; set; }

    [Association("User-UserSupport")]
    public UserEntity User { get; set; }

    public string Comment { get; set; }

    public UserSupportEntity(Session session) : base(session) { }
}
