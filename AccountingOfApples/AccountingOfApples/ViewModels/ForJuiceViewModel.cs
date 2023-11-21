using System.ComponentModel.DataAnnotations;

namespace AccountingOfApples.ViewModels;

public class ForJuiceViewModel
{
    public Guid? Id { get; set; }

    [Required]
    public Guid? OwnerId { get; set; }

    [Required]
    public double? Price { get; set; }

    [Required]
    public int? Weight { get; set; }

    public DateOnly Date { get; set; }
}
