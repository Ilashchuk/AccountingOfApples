using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class Packaging
{
    public Guid Id { get; set; }

    public double? Price { get; set; }

    public ICollection<OrderAppleVariety> OrderAppleVarieties { get; set; } = new List<OrderAppleVariety>();
}
