using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities
{
    [Persistent("TiketProperty")]
    public class TiketPreorityEntites : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        public string Name { get; set; }

        public TiketPreorityEntites(Session session) : base(session) { }

    }
}
