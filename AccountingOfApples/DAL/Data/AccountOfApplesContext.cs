using DAL.Models;
using HRM.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    internal class AccountOfApplesContext : DbContext
    {
        public DbSet<Area> Areas { get; set; } = null!;
        public DbSet<AreaAppleVariety> AreaAppleVarieties { get; set; } = null!;
        public DbSet<AppleVariety> AppleVarieties { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<OrderAppleVariety> OrderAppleVarieties { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<ForJuice> ForJuices { get; set; } = null!;
        public AccountOfApplesContext(DbContextOptions<AccountOfApplesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
