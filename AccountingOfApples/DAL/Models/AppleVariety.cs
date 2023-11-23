namespace DAL.Models;

public class AppleVariety
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public ICollection<OrderAppleVariety>? OrderAppleVarieties { get; set; } = new List<OrderAppleVariety>();

    public ICollection<AreaAppleVariety> AreaAppleVarieties { get; set; } = new List<AreaAppleVariety>();
}
