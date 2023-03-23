using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webAPI2.Models;

public partial class UserTable
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter Email")]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter Password")]
    [Display(Name = "Password")]
    public string? Password { get; set; }
}
