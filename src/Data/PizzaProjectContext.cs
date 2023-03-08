using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Models;

namespace PizzaProject.Data
{
    public class PizzaProjectContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public PizzaProjectContext (DbContextOptions<PizzaProjectContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaProject.Models.Pizza> Pizza { get; set; } = default!;
        public DbSet<PizzaProject.Models.Order> Order { get; set; } = default!;
        public DbSet<PizzaProject.Models.Status> Status { get; set; } = default!;

    }
}
