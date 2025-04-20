using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace RealEstateAgencySystem.Models
{
    public class AppDbContext : IdentityDbContext<Customer>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyAmenities> PropertyAmenities { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
        public DbSet<RentalRecord> RentalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<SalesRecord>()
                .HasOne(s => s.OwnerCustomer)
                .WithMany(c => c.SalesAsOwner)
                .HasForeignKey(s => s.OwnerCustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesRecord>()
                .HasOne(s => s.BuyerCustomer)
                .WithMany(c => c.SalesAsBuyer)
                .HasForeignKey(s => s.BuyerCustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalRecord>()
                .HasOne(r => r.OwnerCustomer)
                .WithMany(c => c.RentalsAsOwner)
                .HasForeignKey(r => r.OwnerCustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalRecord>()
                .HasOne(r => r.TenantCustomer)
                .WithMany(c => c.RentalsAsTenant)
                .HasForeignKey(r => r.TenantCustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Property)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAmenities>()
                .HasOne(pa => pa.Property)
                .WithOne(p => p.PropertyAmenities)
                .HasForeignKey<PropertyAmenities>(pa => pa.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SalesRecord>()
                .HasOne(sc => sc.Property)
                .WithMany(p => p.SalesRecords)
                .HasForeignKey(sc => sc.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalRecord>()
                .HasOne(rc => rc.Property)
                .WithMany(p => p.RentalRecords)
                .HasForeignKey(rc => rc.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }

    }
}