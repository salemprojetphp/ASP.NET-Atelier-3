using MyFrstMVCApp.Models;

public class MembershipType
{
    public int Id { get; set; }
    public float signupFee { get; set; }
    public int durationInMonths { get; set; }
    public float discountRate { get; set; }
    public ICollection<Client>? Clients { get; set; }
}   
