using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CardTasks.Models;

public partial class CurrentUser
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")] // to check if the input is emoty or not 
    [StringLength(5, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string? Password { get; set; }
}
