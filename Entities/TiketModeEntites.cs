using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities
{
    [Persistent("TiketMode")]
    public class TiketModeEntites: XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        public string Name { get; set; }

        public TiketModeEntites(Session session) : base(session) { }
    }
}
