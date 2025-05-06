using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB
{
    [Persistent("Tickets")]
    public class Ticket : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedData { get; set; }
        public DateTime UpdateData { get; set; }
        public DateTime ClosedData { get; set; }


        [Association("Ticket-UserSupport")]
        public XPCollection<UserSupport> Supports => GetCollection<UserSupport>(nameof(Supports));
        [Association("User-Tickets")]
        public User Creator { get; set; }
        [Association("Company-Tickets")]
        public Company Company { get; set; }
        [Association("Status-Tickets")]
        public Status Status { get; set; }

        public Ticket(Session session) : base(session) { }
    }
}
