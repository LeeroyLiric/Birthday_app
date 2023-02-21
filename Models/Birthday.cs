using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Сongratulator.Models;

public partial class Birthday
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;

    public string? Surname { get; set; }
}
