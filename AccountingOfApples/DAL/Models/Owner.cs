using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Percent { get; set; }
        public ICollection<Area> Areas { get; set; } = new List<Area>();
        public ICollection<ForJuice> ForJuices { get; set; } = new List<ForJuice>();
    }
}
