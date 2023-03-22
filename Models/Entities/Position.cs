namespace HR_Service.Models.Enitty;

public class Position
{
  public Guid id { get; set; }
  public string name { get; set; } = string.Empty;
  public string code { get; set; } = string.Empty;
  public int level { get; set; }
  public bool is_active { get; set; }
}