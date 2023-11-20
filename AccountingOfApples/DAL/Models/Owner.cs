using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class Owner
{
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public int Percent { get; set; }

    public ICollection<Area> Areas { get; set; } = new List<Area>();

    public ICollection<ForJuice> ForJuices { get; set; } = new List<ForJuice>();
}
