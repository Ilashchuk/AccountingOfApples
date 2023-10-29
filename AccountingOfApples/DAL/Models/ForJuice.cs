using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class ForJuice
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public DateOnly Date { get; set; }
        public Owner Owner { get; set; }

    }
}
