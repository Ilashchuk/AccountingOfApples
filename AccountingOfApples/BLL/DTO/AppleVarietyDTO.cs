namespace DAL.Models;

public class AppleVarietyDTO
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public ICollection<OrderAppleVarietyDTO> OrderAppleVarieties { get; set; } = new List<OrderAppleVarietyDTO>();

    public ICollection<AreaDTO> AreaAppleVarieties { get; set; } = new List<AreaDTO>();
}
