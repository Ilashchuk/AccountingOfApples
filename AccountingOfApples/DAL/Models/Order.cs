using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [NotMapped]
        public DateOnly Date { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateDb
        {
            get => Date.ToDateTime(TimeOnly.MinValue);
            set => Date = DateOnly.FromDateTime(value);
        }
        public Guid ClientId { get; set; }

        public Client? Client { get; set; }
        public ICollection<OrderAppleVariety> OrderAppleVarieties { get; set; } = new List<OrderAppleVariety>();
    }
}
