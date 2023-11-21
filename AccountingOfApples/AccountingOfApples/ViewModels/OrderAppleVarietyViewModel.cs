using BLL.DTO;

namespace AccountingOfApples.ViewModels;

public class OrderAppleVarietyViewModel
{
    public Guid? Id { get; set; }

    public double? Price { get; set; }

    public double? Weight { get; set; }

    public int? CountOfBoxes { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? AppleVarietyId { get; set; }

    public Guid? AreaId { get; set; }

    public OrderViewModel? Order { get; set; }

    public AppleVarietyViewModel? AppleVariety { get; set; }

    public AreaViewModel? Area { get; set; }
}
