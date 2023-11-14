using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AreaDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Square { get; set; }
        public Guid OwnerId { get; set; }
        public ICollection<OrderAppleVarietyDTO> OrderAppleVarieties { get; set; } = new List<OrderAppleVarietyDTO>();
        public OwnerDTO? Owner { get; set; }
        public ICollection<AppleVarietyDTO> AreaAppleVarieties { get; set; } = new List<AppleVarietyDTO>();
    }
}
