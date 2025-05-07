using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB
{
    [Persistent("Companies")]
    public class Company : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Mail { get; set; }
        public string Logo { get; set; }
        public string IDNO { get; set; }
        public bool Status { get; set; }

        [Association("Company-Users")]
        public XPCollection<UserEntites> Users => GetCollection<UserEntites>(nameof(Users));

        public Company(Session session) : base(session) { }
    }
}
