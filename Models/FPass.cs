using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI2.Models
{
    public class FPass
{ 
  public int Id { get; set; }
  public string? Email { get; set; }
  public string? OldPassword { get; set; }
  public string? NewPassword { get; set; }
  public string? Password { get; set; }

}
}