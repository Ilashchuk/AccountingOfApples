using System.ComponentModel.DataAnnotations;

namespace AccountingOfApples.ViewModels;

public class OwnerViewModel
{
    public Guid? Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int? Percent { get; set; }
}
