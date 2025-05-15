using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB;

[Persistent("Companies")]
public class Company : XPLiteObject
{
    [Key(true)]
    public int ID { get; set; }

    public string Name { get; set; }
    public string Mail { get; set; }
    public string Logo { get; set; }
    public string IDNO { get; set; }
    public bool Status { get; set; } = true;
    public bool Vip { get; set; } = false;

    [Association("Company-Users")]
    public XPCollection<UserEntity> Users => GetCollection<UserEntity>(nameof(Users));

    public Company(Session session) : base(session) { }
}
