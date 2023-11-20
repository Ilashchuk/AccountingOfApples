using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class OwnerDTO
{
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public int Percent { get; set; }

    public ICollection<AreaDTO> Areas { get; set; } = new List<AreaDTO>();

    public ICollection<ForJuiceDTO> ForJuices { get; set; } = new List<ForJuiceDTO>();
}
