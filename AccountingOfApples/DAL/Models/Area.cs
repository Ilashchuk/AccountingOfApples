namespace DAL.Models;

public class Area
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public double Square { get; set; }

    public Guid OwnerId { get; set; }

    public ICollection<OrderAppleVariety> OrderAppleVarieties { get; set; } = new List<OrderAppleVariety>();

    public Owner? Owner { get; set; }

    public ICollection<AreaAppleVariety> AreaAppleVarieties { get; set; } = new List<AreaAppleVariety>();

}
