namespace kept_server.Models
{
  public class Vault
  {
    public int Id { get; set; }
    public string creatorId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    public bool IsPublished { get; set; }
    public Profile Creator { get; set; }

  }
}