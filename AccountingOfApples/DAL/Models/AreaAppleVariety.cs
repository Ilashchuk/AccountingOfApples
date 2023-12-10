namespace DAL.Models;

public class AreaAppleVariety
{
    public Guid Id { get; set; }

    public Guid AreaId { get; set; }

    public Guid AppleVarietyId { get; set; }

    public Area? Area { get; set; }

    public AppleVariety? AppleVariety { get; set; }
}
