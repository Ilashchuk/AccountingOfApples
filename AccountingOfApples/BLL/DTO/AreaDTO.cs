namespace BLL.DTO;

public class AreaDTO
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public double Square { get; set; }

    public Guid OwnerId { get; set; }

    public ICollection<OrderAppleVarietyDTO> OrderAppleVarieties { get; set; } = new List<OrderAppleVarietyDTO>();

    public OwnerDTO? Owner { get; set; }

    public ICollection<AppleVarietyDTO> AppleVarieties { get; set; } = new List<AppleVarietyDTO>();
}
