using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities;

[Persistent("TiketMode")]
public class TiketModeEntity: XPLiteObject
{
    [Key(true)]
    public int ID { get; set; }

    public string Name { get; set; }

    public TiketModeEntity(Session session) : base(session) { }
}
