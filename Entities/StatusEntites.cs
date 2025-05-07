using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB
{
    [Persistent("Statuses")]
    public class StatusEntites : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        public string Name { get; set; }

        public StatusEntites(Session session) : base(session) { }
    }
}
