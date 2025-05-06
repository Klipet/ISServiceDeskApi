using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB
{
    [Persistent("UserSupport")]
    public class UserSupport : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        [Association("Ticket-UserSupport")]
        public Ticket Ticket { get; set; }

        [Association("User-UserSupport")]
        public User User { get; set; }

        public string Comment { get; set; }

        public UserSupport(Session session) : base(session) { }
    }
}
