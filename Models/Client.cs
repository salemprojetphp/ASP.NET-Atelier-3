namespace MyFrstMVCApp.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    //Foreigh Key
    public int MembershipTypeId { get; set; }
    public MembershipType? MembershipType { get; set; }
    public ICollection<MovieClient>? MovieClients { get; set; }
}