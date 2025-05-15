using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities;

[Persistent("TiketType")]
public class TiketTypeEntity: XPLiteObject
{
    [Key(true)]
    public int ID { get; set; }

    public string Name { get; set; }

    public TiketTypeEntity(Session session) : base(session) { }
}
