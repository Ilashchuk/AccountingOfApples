using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ForJuiceDTO
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        [NotMapped]
        public DateOnly Date { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateDb { 
            get => Date.ToDateTime(TimeOnly.MinValue); 
            set => Date = DateOnly.FromDateTime(value); }
        public OwnerDTO? Owner { get; set; }

    }
}
