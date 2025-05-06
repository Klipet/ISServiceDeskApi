using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB
{
    [Persistent("Statuses")]
    public class Status : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        public string Name { get; set; }

        public Status(Session session) : base(session) { }
    }
}
