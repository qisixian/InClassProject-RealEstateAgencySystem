using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstateAgencySystem.Models
{
    public static class SeedUser 
    {
        public static async Task SeedAdminUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();

            var random = new Random();
            string[] countries = { "Canada" };
            string[] provinces = { "BC" };
            string[] cities = { "Vancouver", "North Vancouver", "West Vancouver", "Burnaby", "New Westminster", "Richmond", "Delta", "Coquitlam", "Surrey", "Langley" };
            string[] commonNames = new string[]{ "John Smith", "Emily Johnson", "Michael Williams", "Sarah Brown", "David Miller", "Jessica Davis", "James Wilson", "Laura Martinez", "Robert Anderson", "Sophia Thomas", "Daniel Taylor", "Olivia Moore", "Matthew Jackson", "Isabella White", "Christopher Harris", "Emma Martin", "Joshua Thompson", "Ava Garcia", "Andrew Lee", "Mia Robinson"};
            

            for (int i = 1; i <= 2; i++)
            {
                string email = $"admin{i}@a.com";

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var customer = new Customer
                    {
                        UserName = email,
                        Email = email,
                        Name = commonNames[i - 1],
                        PhoneNumber = $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}",
                        ContactAddress = $"{random.Next(100, 9999)} {(char)(65 + random.Next(26))} St, {cities[random.Next(cities.Length)]}, BC, Canada",
                        PostalCode = $"V{random.Next(1, 10)}{(char)(65 + random.Next(26))}{random.Next(1, 10)}{(char)(65 + random.Next(26))}{random.Next(1, 10)}"
                    };

                    var result = await userManager.CreateAsync(customer, "Password1!");
                    Console.WriteLine(result.ToString());
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(customer, "Admin");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to create user {email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                    // await userManager.AddToRoleAsync(customer, "Admin");
                }
            }
        }

        public static async Task CreateRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            string[] roleNames = { "Admin", "Buyer", "Saler" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

    }
}