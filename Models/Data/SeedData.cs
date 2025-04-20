using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstateAgencySystem.Models
{
    public static class SeedData
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {

            var context = serviceProvider.GetRequiredService<AppDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();
            var salerCustomer = await userManager.FindByEmailAsync("admin1@a.com");
            var buyerCustomer = await userManager.FindByEmailAsync("admin2@a.com");

            if (salerCustomer == null || buyerCustomer == null)
            {
                throw new Exception("Seed users not found.");
            }

            var random = new Random();

            await SeedPropertiesAsync(context, salerCustomer);
            await SeedAmenitiesAsync(context);
            await SeedImagesAsync(context);
            await SeedSalesRecordsAsync(context, salerCustomer, buyerCustomer);
            await SeedRentalRecordsAsync(context, salerCustomer, buyerCustomer);

        }

        public class PropertyTypeConfig
        {
            public required string PropertyType { get; init; }
            public double PriceFactor { get; init; }
            public required string Description { get; init; }
            public (int Min, int Max) Bedrooms { get; init; }
            public (int Min, int Max) Bathrooms { get; init; }
            public (int Min, int Max) Size { get; init; }
            public (int Min, int Max) Year { get; init; }
        }

        public static async Task SeedPropertiesAsync(AppDbContext context, Customer salerCustomer)
        {
            if (context.Properties.Any()) return;

            var random = new Random();
            string[] countries = { "Canada" };
            string[] provinces = { "BC" };
            string[] cities = { "Vancouver", "North Vancouver", "West Vancouver", "Burnaby", "New Westminster", "Richmond", "Delta", "Coquitlam", "Surrey", "Langley" };
            string[] statuses = { "For Sale", "For Rent", "Sold", "Rented" };
            string[] propertyTypes = { "House", "Apartment", "Condo", "Townhouse", "Basement Suite", "Duplex" };

            // 创建房产类型配置列表
            var propertyConfigs = new List<PropertyTypeConfig>
            {
                new PropertyTypeConfig 
                { 
                    PropertyType = "House",
                    PriceFactor = 2.0,
                    Description = "Magnificent luxury house with spacious rooms and high-end finishes.",
                    Bedrooms = (4, 7),
                    Bathrooms = (3, 6),
                    Size = (3000, 8000),
                    Year = (2000, 2023)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "House",
                    PriceFactor = 1.6,
                    Description = "Charming family home in a quiet neighborhood.",
                    Bedrooms = (3, 5),
                    Bathrooms = (2, 4),
                    Size = (1800, 3500),
                    Year = (1990, 2023)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "Townhouse",
                    PriceFactor = 1.4,
                    Description = "Beautiful townhouse in a well-maintained complex.",
                    Bedrooms = (2, 4),
                    Bathrooms = (2, 3),
                    Size = (1200, 2400),
                    Year = (1995, 2023)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "Condo",
                    PriceFactor = 1.2,
                    Description = "High-end condo with premium finishes.",
                    Bedrooms = (2, 3),
                    Bathrooms = (2, 3),
                    Size = (1000, 2200),
                    Year = (2005, 2023)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "Condo",
                    PriceFactor = 1.0,
                    Description = "Well-maintained condo in great location.",
                    Bedrooms = (1, 3),
                    Bathrooms = (1, 2),
                    Size = (700, 1400),
                    Year = (1990, 2023)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "Condo",
                    PriceFactor = 1.0,
                    Description = "Comfortable condo perfect for urban living.",
                    Bedrooms = (1, 3),
                    Bathrooms = (1, 2),
                    Size = (700, 1400),
                    Year = (1990, 2023)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "Apartment",
                    PriceFactor = 0.9,
                    Description = "Modern studio apartment with smart design.",
                    Bedrooms = (0, 1),
                    Bathrooms = (1, 1),
                    Size = (400, 700),
                    Year = (1980, 2023)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "Apartment",
                    PriceFactor = 0.9,
                    Description = "Stylish studio in vibrant neighborhood.",
                    Bedrooms = (0, 1),
                    Bathrooms = (1, 1),
                    Size = (400, 700),
                    Year = (1980, 2023)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "Basement Suite",
                    PriceFactor = 0.7,
                    Description = "Renovated basement suite with private entrance.",
                    Bedrooms = (1, 2),
                    Bathrooms = (1, 1),
                    Size = (500, 900),
                    Year = (1970, 2020)
                },
                
                new PropertyTypeConfig 
                { 
                    PropertyType = "Duplex",
                    PriceFactor = 1.5,
                    Description = "Well-maintained duplex in family-friendly area.",
                    Bedrooms = (2, 4),
                    Bathrooms = (2, 3),
                    Size = (1400, 2800),
                    Year = (1980, 2023)
                }
            };

            var properties = new List<Property>();

            // 为每种状态创建10个物业
            foreach (var status in statuses)
            {
                foreach (var config in propertyConfigs)
                {
                    int bedrooms = random.Next(config.Bedrooms.Min, config.Bedrooms.Max + 1);
                    int bathrooms = random.Next(config.Bathrooms.Min, config.Bathrooms.Max + 1);
                    int size = random.Next(config.Size.Min, config.Size.Max + 1);
                    int buildYear = random.Next(config.Year.Min, config.Year.Max + 1);
                    
                    // calculate price factor
                    double bedroomFactor = bedrooms * 0.2;
                    double bathroomFactor = bathrooms * 0.15;
                    double sizeFactor = (size / 500.0) * 0.2;
                    double ageAdjustment = 1.0 - (2025 - buildYear) / 50.0;
                    ageAdjustment = Math.Max(0.2, ageAdjustment);
                    double totalFactor = config.PriceFactor * (0.5 + ageAdjustment + bedroomFactor + bathroomFactor + sizeFactor);
                    
                    decimal? sellingPrice = null;
                    decimal? rentalPrice = null;
                    if (status == "For Sale" || status == "Sold")
                    {
                        // 生成在500,000到3,000,000之间的合理售价
                        double basePrice = 300000;
                        double priceRange = 1000000 * totalFactor; // 根据所有因素调整价格范围
                        sellingPrice = Math.Round((decimal)(basePrice + random.NextDouble() * priceRange), 0);
                        
                        // 确保价格范围在要求的区间内
                        sellingPrice = Math.Max(300000, Math.Min(5000000, sellingPrice.Value));
                    }
                    
                    if (status == "For Rent" || status == "Rented")
                    {
                        // 生成在1,500到5,000之间的合理租金
                        double baseRent = 1500;
                        double rentRange = 3500 * totalFactor; // 根据所有因素调整租金范围
                        rentalPrice = Math.Round((decimal)(baseRent + random.NextDouble() * rentRange), 0);
                        
                        // 确保租金范围在要求的区间内
                        rentalPrice = Math.Max(1500, Math.Min(5000, rentalPrice.Value));
                    }
                    
                    string city = cities[random.Next(cities.Length)];
                    string postalCode = $"V{random.Next(1, 10)}{(char)(65 + random.Next(26))}{random.Next(1, 10)}{(char)(65 + random.Next(26))}{random.Next(1, 10)}";

                    var property = new Property
                    {
                        Country = countries[0],
                        Province = provinces[0],
                        City = city,
                        PostalCode = postalCode,
                        PropertyAddress = $"{random.Next(100, 9999)} {(char)(65 + random.Next(26))} {(random.Next(2) == 0 ? "Ave" : "St")}",
                        PropertyType = config.PropertyType,
                        BuildYear = buildYear,
                        SizeOfHouse = size,
                        Bedrooms = bedrooms,
                        Bathrooms = bathrooms,
                        CurrentStatus = status,
                        ListingDate = status == "Sold" || status == "Rented" 
                            ? DateTime.Now.AddDays(-random.Next(90, 180)) 
                            : DateTime.Now.AddDays(-random.Next(1, 90)),
                        SellingPrice = sellingPrice,
                        RentalPrice = rentalPrice,
                        Description = config.Description,
                        OwnerCustomerId = salerCustomer.Id
                    };
                    
                    properties.Add(property);
                }
            }

            await context.Properties.AddRangeAsync(properties);
            await context.SaveChangesAsync();
            
            Console.WriteLine($"Seeded {properties.Count} properties");
        }

        public static async Task SeedAmenitiesAsync(AppDbContext context)
        {
            if (context.PropertyAmenities.Any()) return;

            // Seed PropertyAmenities
            var random = new Random();
            var amenities = new List<PropertyAmenities>();

            var properties = context.Properties.ToList();
            if (properties.Count == 0) return;
            foreach (var property in properties)
            {
                amenities.Add(new PropertyAmenities
                {
                    PropertyId = property.PropertyId,
                    Elevator = random.Next(2) == 1,
                    Refrigerator = true,
                    Cooktop = true,
                    Microwave = random.Next(2) == 1,
                    Dishwasher = random.Next(2) == 1,
                    FireSprinklerSystem = random.Next(2) == 1,
                    Washer = true,
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

            await context.PropertyAmenities.AddRangeAsync(amenities);
            await context.SaveChangesAsync();

            Console.WriteLine($"Seeded {amenities.Count} PropertyAmenities");
        }

        public static async Task SeedImagesAsync(AppDbContext context)
        {
            if (context.Images.Any()) return;

            // Add Images
            var random = new Random();
            var images = new List<Image>();
            var properties = context.Properties.ToList();
            if (properties.Count == 0) return;
            foreach (var property in properties)
            {
                for (int i = 1; i <= 3; i++)
                {
                    string imagePath = Path.Combine("Models/Data", $"sample_image_{random.Next(1, 12)}.jpg");
                    if (File.Exists(imagePath))
                    {
                        byte[] imageData = await File.ReadAllBytesAsync(imagePath);
                        images.Add(new Image
                        {
                            PropertyId = property.PropertyId,
                            FileName = $"property_{property.PropertyId}_img_{i}.jpg",
                            ContentType = "image/jpeg",
                            ImageData = imageData
                        });
                    } else
                    {
                        Console.WriteLine($"Image not found: {imagePath}");
                    }
                }
            }

            await context.Images.AddRangeAsync(images);
            await context.SaveChangesAsync();

            Console.WriteLine($"Seeded {images.Count} Images");
        }

        public static async Task SeedSalesRecordsAsync(AppDbContext context, Customer salerCustomer, Customer buyerCustomer)
        {
            if (context.SalesRecords.Any()) return;

            // Seed SalesContracts
            var random = new Random();
            var salesRecords = new List<SalesRecord>();
            string salesContractTerms = "Standard sale contract terms with 30-day closing period. Buyer is responsible for inspection costs.";
            var soldProperties = context.Properties
                .Where(p => p.CurrentStatus == "Sold")
                .ToList();
            if (soldProperties.Count == 0) return;
            foreach (var soldProperty in soldProperties)
            {
                salesRecords.Add(new SalesRecord
                {
                    OwnerCustomerId = salerCustomer.Id,
                    BuyerCustomerId = buyerCustomer.Id,
                    PropertyId = soldProperty.PropertyId,
                    ContractTerms = salesContractTerms,
                    SalePrice = soldProperty.SellingPrice ?? throw new Exception($"SellingPrice is null for PropertyId {soldProperty.PropertyId}"),
                    TransactionDate = DateTime.Now.AddDays(-random.Next(1, 90)),
                    IsFinalized = true
                });
            }

            await context.SalesRecords.AddRangeAsync(salesRecords);
            await context.SaveChangesAsync();

            Console.WriteLine($"Seeded {salesRecords.Count} SalesRecords");
        }

        public static async Task SeedRentalRecordsAsync(AppDbContext context, Customer salerCustomer, Customer buyerCustomer)
        {
            if (context.RentalRecords.Any()) return;

            // Seed RentalContracts
            var random = new Random();
            var rentalRecords = new List<RentalRecord>();
            string rentalContractTerms = "Month-to-month lease with 30-day notice required for termination.";
            var rentedProperties = context.Properties
                .Where(p => p.CurrentStatus == "Rented")
                .ToList();
            if (rentedProperties.Count == 0) return;
            foreach (var rentedProperty in rentedProperties)
            {

                var startDate = rentedProperty.ListingDate.AddDays(random.Next(5, 30));

                rentalRecords.Add(new RentalRecord
                {
                    OwnerCustomerId = salerCustomer.Id,
                    TenantCustomerId = buyerCustomer.Id,
                    PropertyId = rentedProperty.PropertyId,
                    ContractTerms = rentalContractTerms,
                    RentalPrice = rentedProperty.RentalPrice ?? throw new Exception($"RentalPrice is null for PropertyId {rentedProperty.PropertyId}"),
                    DepositPrice = (rentedProperty.RentalPrice ?? throw new Exception($"RentalPrice is null for PropertyId {rentedProperty.PropertyId}")) / 2,
                    StartDate = startDate,
                    EndDate = startDate.AddMonths(6), // 6 months to 2 years lease
                    IsFinalized = true,
                });
            }

            await context.RentalRecords.AddRangeAsync(rentalRecords);
            await context.SaveChangesAsync();

            Console.WriteLine($"Seeded {rentalRecords.Count} RentalRecords");
        }

    }
}
