namespace DAL.Models;

public class OrderAppleVariety
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid AppleVarietyId { get; set; }

    public Guid AreaId { get; set; }

    public Guid PackagingId { get; set; }

    public double Price { get; set; }

    public double Weight { get; set; }

    public int CountOfBoxes { get; set; }

    public Order? Order { get; set; }

    public AppleVariety? AppleVariety { get; set; }

    public Area? Area { get; set; }

    public Packaging? Packaging { get; set; }

}
