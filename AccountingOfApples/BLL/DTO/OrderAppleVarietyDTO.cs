namespace BLL.DTO;
public class OrderAppleVarietyDTO
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid AppleVarietyId { get; set; }

    public Guid AreaId { get; set; }

    public double Price { get; set; }

    public double Weight { get; set; }

    public int CountOfBoxes { get; set; }

    public OrderDTO? Order { get; set; }

    public AppleVarietyDTO? AppleVariety { get; set; }

    public AreaDTO? Area { get; set; }

}
