using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace RealEstateAgencySystem.Models
{
    public class AppDbContext : IdentityDbContext
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
        public DbSet<SalesContract> SalesContracts { get; set; }
        public DbSet<RentalContract> RentalContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<SalesContract>()
                .HasOne(s => s.OwnerCustomer)
                .WithMany(c => c.SalesAsOwner)
                .HasForeignKey(s => s.OwnerCustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesContract>()
                .HasOne(s => s.BuyerCustomer)
                .WithMany(c => c.SalesAsBuyer)
                .HasForeignKey(s => s.BuyerCustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalContract>()
                .HasOne(r => r.OwnerCustomer)
                .WithMany(c => c.RentalsAsOwner)
                .HasForeignKey(r => r.OwnerCustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalContract>()
                .HasOne(r => r.TenantCustomer)
                .WithMany(c => c.RentalsAsTenant)
                .HasForeignKey(r => r.TenantCustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Property)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PropertyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAmenities>()
                .HasOne(pa => pa.Property)
                .WithOne(p => p.PropertyAmenities)
                .HasForeignKey<PropertyAmenities>(pa => pa.PropertyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SalesContract>()
                .HasOne(sc => sc.Property)
                .WithMany(p => p.SalesContracts)
                .HasForeignKey(sc => sc.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalContract>()
                .HasOne(rc => rc.Property)
                .WithMany(p => p.RentalContracts)
                .HasForeignKey(rc => rc.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Seed data
            // If you dont want to update seed data to random value every time you apply migration,
            //  you should comment out the following line
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var random = new Random();
            string[] countries = { "Canada" };
            string[] provinces = { "BC" };
            string[] cities = { "Vancouver", "North Vancouver", "West Vancouver", "Burnaby", "New Westminster", "Richmond", "Delta", "Coquitlam", "Surrey", "Langley" };
            // Seed Customers
            var customers = new List<Customer>();
            string[] commonNames = new string[]{ "John Smith", "Emily Johnson", "Michael Williams", "Sarah Brown", "David Miller", "Jessica Davis", "James Wilson", "Laura Martinez", "Robert Anderson", "Sophia Thomas", "Daniel Taylor", "Olivia Moore", "Matthew Jackson", "Isabella White", "Christopher Harris", "Emma Martin", "Joshua Thompson", "Ava Garcia", "Andrew Lee", "Mia Robinson"};
            for (int i = 1; i <= 20; i++)
            {
                customers.Add(new Customer
                {
                    CustomerId = i,
                    Name = commonNames[i-1],
                    Phone = $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}",
                    Email = $"customer{i}@example.com",
                    ContactAddress = $"{random.Next(100, 9999)} {(char)(65 + random.Next(26))} St, {cities[random.Next(cities.Length)]}, {provinces[random.Next(provinces.Length)]}, {countries[random.Next(countries.Length)]}",
                    PostalCode = $"V{random.Next(1, 10)}{(char)(65 + random.Next(26))}{random.Next(1, 10)}{(char)(65 + random.Next(26))}{random.Next(1, 10)}",
                    Password = "Password123!",
                });
            }
            modelBuilder.Entity<Customer>().HasData(customers);

            // Seed Properties
            var properties = new List<Property>();
            string[] propertyTypes = { "House", "Apartment", "Condo", "Townhouse", "Duplex" };
            string[] statuses = { "For Sale", "For Rent", "Sold", "Rented" };
            for (int i = 1; i <= 20; i++)
            {
                var status = statuses[random.Next(statuses.Length)];
                var ownerId = random.Next(1, 21); // Random owner from customers
                
                properties.Add(new Property
                {
                    PropertyID = i,
                    Country = countries[random.Next(countries.Length)],
                    Province = provinces[random.Next(provinces.Length)],
                    City = cities[random.Next(cities.Length)],
                    PostalCode = $"V{random.Next(1, 10)}{(char)(65 + random.Next(26))}{random.Next(1, 10)}{(char)(65 + random.Next(26))}{random.Next(1, 10)}",
                    PropertyAddress = $"{random.Next(100, 9999)} {(char)(65 + random.Next(26))} Ave",
                    PropertyType = propertyTypes[random.Next(propertyTypes.Length)],
                    BuildYear = random.Next(1980, 2023),
                    SizeOfHouse = random.Next(800, 5000),
                    Bedrooms = random.Next(1, 6),
                    Bathrooms = random.Next(1, 5),
                    CurrentStatus = status,
                    ListingDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                    RentalPrice = status == "For Rent" || status == "Rented" ? (decimal)(random.Next(1000, 5000)) : null,
                    SellingPrice = status == "For Sale" || status == "Sold" ? (decimal)(random.Next(200000, 2000000)) : null,
                    Description = $"Beautiful {propertyTypes[random.Next(propertyTypes.Length)]} in a great neighborhood. Built in {random.Next(1980, 2023)}.",
                    OwnerCustomerID = ownerId,
                });
            }
            modelBuilder.Entity<Property>().HasData(properties);

            // Seed PropertyAmenities
            var amenities = new List<PropertyAmenities>();
            for (int i = 1; i <= 20; i++)
            {
                amenities.Add(new PropertyAmenities
                {
                    PropertyAmenitiesID = i,
                    PropertyID = i,
                    Elevator = random.Next(2) == 1,
                    Refrigerator = random.Next(2) == 1,
                    Cooktop = random.Next(2) == 1,
                    Microwave = random.Next(2) == 1,
                    Dishwasher = random.Next(2) == 1,
                    FireSprinklerSystem = random.Next(2) == 1,
                    Washer = random.Next(2) == 1,
                    Dryer = random.Next(2) == 1,
                    Heating = random.Next(2) == 1,
                    AirConditioning = random.Next(2) == 1,
                    SecuritySystem = random.Next(2) == 1,
                    PetFriendly = random.Next(2) == 1,
                    FitnessRoom = random.Next(2) == 1,
                    SwimmingPool = random.Next(2) == 1,
                    ParkingLot = random.Next(2) == 1,
                    Locker = random.Next(2) == 1,
                    OtherAmenities = random.Next(3) == 0 ? "Close to public transport, shopping center nearby" : ""
                });
            }
            modelBuilder.Entity<PropertyAmenities>().HasData(amenities);

            // Seed Images (sample images, you would need real image data in a real application)
            var images = new List<Image>();
            for (int i = 1; i <= 60; i++)
            {
                // Assign each property 3 images
                var propertyId = ((i - 1) / 3) + 1;

                int sampleImageNum = random.Next(1, 11);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"sample_image_{sampleImageNum}.jpg");

                if (File.Exists(imagePath))
                {
                    byte[] imageData = System.IO.File.ReadAllBytes(imagePath);

                    images.Add(new Image
                    {
                        ImageID = i,
                        PropertyID = propertyId,
                        FileName = $"property_{propertyId}_image_{i % 3 + 1}.jpg",
                        ContentType = "image/jpeg",
                        ImageData = imageData
                    });
                }
                
            }
            modelBuilder.Entity<Image>().HasData(images);

            // // Seed SalesContracts
            // var salesContracts = new List<SalesContract>();
            // string salesContractTerms = "Standard sale contract terms with 30-day closing period. Buyer is responsible for inspection costs.";
            // for (int i = 1; i <= 5; i++)
            // {
            //     var ownerId = properties[i-1].OwnerCustomerID.Value;
            //     var buyerId = ((ownerId + random.Next(1, 19)) % 20) + 1; // Different customer as buyer
                
            //     salesContracts.Add(new SalesContract
            //     {
            //         SalesContractsID = i,
            //         OwnerCustomerID = ownerId,
            //         BuyerCustomerID = buyerId,
            //         PropertyID = i,
            //         ContractTerms = salesContractTerms;
            //         SalePrice = properties[i-1].SellingPrice ?? 300000, // Use property's selling price
            //         TransactionDate = DateTime.Now.AddDays(-random.Next(1, 90)),
            //         IsFinalized = true
            //     });
            // }
            // modelBuilder.Entity<SalesContract>().HasData(salesContracts);

            // // Seed RentalContracts
            // var rentalContracts = new List<RentalContract>();
            // string[] rentalContractTerms = "Month-to-month lease with 30-day notice required for termination.";
            // for (int i = 1; i <= 5; i++)
            // {
            //     var ownerId = properties[i-1].OwnerCustomerID.Value;
            //     var tenantId = ((ownerId + random.Next(1, 19)) % 20) + 1; // Different customer as tenant
                
            //     var startDate = DateTime.Now.AddDays(-random.Next(1, 30));
                
            //     rentalContracts.Add(new RentalContract
            //     {
            //         RentalContractID = i,
            //         OwnerCustomerID = ownerId,
            //         TenantCustomerID = tenantId,
            //         PropertyID = i,
            //         ContractTerms = rentalContractTerms,
            //         RentalPrice = properties[i-1].RentalPrice ?? 1500, // Use property's rental price
            //         DepositPrice = properties[i-1].RentalPrice ?? 1500, // Usually one month's rent
            //         StartDate = startDate,
            //         EndDate = startDate.AddMonths(random.Next(6, 24)), // 6 months to 2 years lease
            //         IsFinalized = true,
            //     });
            // }
            // modelBuilder.Entity<RentalContract>().HasData(rentalContracts);
        }
    }
}