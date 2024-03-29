﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Models;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Warehouse>().ToTable("Warehouse");
            modelBuilder.Entity<Facility>().ToTable("Facility");
            modelBuilder.Entity<Registration>().ToTable("Registration");

            //modelBuilder.Entity<Order>()
            //    .HasCheckConstraint("CHK_OrderMaterial", "CHECK (Quantity>=Order.Material.MinimumBatch)");
            //modelBuilder.Entity<Material>()
            //    .HasOne(m => m.Supplier)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
