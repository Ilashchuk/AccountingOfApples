using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO;
public class OrderDTO
{
    public Guid Id { get; set; }
    [NotMapped]
    public DateOnly Date { get; set; }

    [Column(TypeName = "date")]
    public DateTime DateDb
    {
        get => Date.ToDateTime(TimeOnly.MinValue);
        set => Date = DateOnly.FromDateTime(value);
    }

    public Guid ClientId { get; set; }

    public ClientDTO? Client { get; set; }

    public ICollection<OrderAppleVarietyDTO> OrderAppleVarieties { get; set; } = new List<OrderAppleVarietyDTO>();
}
