using System.ComponentModel.DataAnnotations;

namespace castle.Models
{
  public class Castle
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int YearBuilt { get; set; }
    public int YearLastInvaded { get; set; }
    public string Location { get; set; }
    public string ImgUrl { get; set; }
  }
}