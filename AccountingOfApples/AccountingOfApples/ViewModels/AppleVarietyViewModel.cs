using System.ComponentModel.DataAnnotations;

namespace AccountingOfApples.ViewModels;

public class AppleVarietyViewModel
{
    public Guid? Id { get; set; }

    [Required]
    public string? Name { get; set; }
}
