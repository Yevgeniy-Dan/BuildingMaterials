using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Models;

namespace BuildingMaterials.Data
{
    public class BuildingMaterialsContext : DbContext
    {
        public BuildingMaterialsContext(DbContextOptions<BuildingMaterialsContext> options)
            : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Material> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<Order>().ToTable("Order");
            //modelBuilder.Entity<Order>()
            //    .HasCheckConstraint("CHK_OrderMaterial", "CHECK (Quantity>=Order.Material.MinimumBatch)");
            //modelBuilder.Entity<Material>()
            //    .HasOne(m => m.Supplier)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
