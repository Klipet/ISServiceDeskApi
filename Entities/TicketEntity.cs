using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB;

[Persistent("Tickets")]
public class TicketEntity : XPLiteObject
{
    [Key(true)]
    public int ID { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedData { get; set; }
    public DateTime UpdateData { get; set; }
    public DateTime ClosedData { get; set; }


    [Association("User-Tickets")]
    public UserEntity Creator { get; set; }
    [Association("Company-Tickets")]
    public Company Company { get; set; }
    [Association("Status-Tickets")]
    public StatusEntites Status { get; set; }

    public TicketEntity(Session session) : base(session) { }
}
