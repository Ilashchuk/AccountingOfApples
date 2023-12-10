using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public class Order
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

    public Client? Client { get; set; }

    public ICollection<OrderAppleVariety> OrderAppleVarieties { get; set; } = new List<OrderAppleVariety>();
}
