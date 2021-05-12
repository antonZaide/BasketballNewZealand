using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasketballNewZealand.Models;

namespace BasketballNewZealand.Data
{
    public class SportContext : DbContext
    {
        public SportContext (DbContextOptions<SportContext> options)
            : base(options)
        {
        }
        public DbSet<Draft> Drafts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Draft>().ToTable("Draft");
        }
    }
}
