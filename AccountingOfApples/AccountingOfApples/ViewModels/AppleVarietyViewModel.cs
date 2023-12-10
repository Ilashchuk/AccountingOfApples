using System.ComponentModel.DataAnnotations;

namespace AccountingOfApples.ViewModels;

public class AppleVarietyViewModel
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public ICollection<AreaViewModel> Areas { get; set; } = new List<AreaViewModel>();
}
