﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderAppleVarietyDTO
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid AppleVarietyId { get; set; }
        public Guid AreaId { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public int CountOfBoxes { get; set; }

        public OrderDTO? Order { get; set; }
        public AppleVarietyDTO? AppleVariety { get; set; }
        public AreaDTO? Area { get; set; }

    }
}
