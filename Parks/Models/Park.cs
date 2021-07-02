using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [StringLength(1000)]
    public string ParkType { get; set; }
    public string Location { get; set; }
  }
}
