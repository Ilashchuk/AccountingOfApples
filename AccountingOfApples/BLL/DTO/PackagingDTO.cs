using DAL.Models;

namespace BLL.DTO;

public class PackagingDTO
{
    public Guid Id { get; set; }

    public double? Price { get; set; }

    public ICollection<OrderAppleVarietyDTO> OrderAppleVarieties { get; set; } = new List<OrderAppleVarietyDTO>();
}
