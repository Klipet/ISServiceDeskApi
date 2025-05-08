using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities
{
    [Persistent("TiketType")]
    public class TiketTypeEntites: XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        public string Name { get; set; }

        public TiketTypeEntites(Session session) : base(session) { }
    }
}
