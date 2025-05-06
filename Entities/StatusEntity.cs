using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities;

[Persistent("Statuses")]
public class StatusEntity(Session session) : XPLiteObject(session)
{
    [Key(true)] public int Id { get; set; }

    public string Name { get; set; }
}