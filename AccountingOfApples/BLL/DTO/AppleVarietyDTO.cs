using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AppleVarietyDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<OrderAppleVarietyDTO> OrderAppleVarieties { get; set; } = new List<OrderAppleVarietyDTO>();
        public ICollection<AreaDTO> AreaAppleVarieties { get; set; } = new List<AreaDTO>();
    }
}
