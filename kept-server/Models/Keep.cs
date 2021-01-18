namespace kept_server.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string creatorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Views { get; set; }
    public bool isPublished { get; set; }
    public int Shares { get; set; }
    public int timesKept { get; set; }
    public Profile Creator { get; set; }
  }
}