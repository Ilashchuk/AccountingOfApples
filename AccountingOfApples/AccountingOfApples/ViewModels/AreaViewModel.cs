using BLL.DTO;
using System.ComponentModel.DataAnnotations;

namespace AccountingOfApples.ViewModels
{
    public class AreaViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public double? Square { get; set; }

        [Required]
        public Guid? OwnerId { get; set; }

        public OwnerViewModel? Owner { get; set; }

        public ICollection<AppleVarietyViewModel> AppleVarieties { get; set; } = new List<AppleVarietyViewModel>();
    }
}
