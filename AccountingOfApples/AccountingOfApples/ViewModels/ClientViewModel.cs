using System.ComponentModel.DataAnnotations;

namespace AccountingOfApples.ViewModels;

public class ClientViewModel
{
    public Guid? Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Phone { get; set; }

    public string Description { get; set; } = null!;
}
