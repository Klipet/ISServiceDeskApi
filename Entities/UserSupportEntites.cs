using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB
{
    [Persistent("UserSupport")]
    public class UserSupportEntites : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        [Association("Ticket-UserSupport")]
        public TicketEntites Ticket { get; set; }

        [Association("User-UserSupport")]
        public UserEntites User { get; set; }

        public string Comment { get; set; }

        public UserSupportEntites(Session session) : base(session) { }
    }
}
