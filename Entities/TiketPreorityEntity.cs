using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities;

[Persistent("TiketProperty")]
public class TiketPreorityEntity : XPLiteObject
{
    [Key(true)]
    public int ID { get; set; }

    public string Name { get; set; }

    public TiketPreorityEntity(Session session) : base(session) { }

}
