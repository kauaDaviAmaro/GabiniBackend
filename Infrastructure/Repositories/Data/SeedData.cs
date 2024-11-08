using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GabiniDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GabiniDbContext>>()))
            {
                // Seed Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User("John Doe", "johndoe", "john@example.com", "1234567890", "1990-01-01", Gender.Male, "12345678901", MaritalStatus.Single, Scholarship.None, "password123"),
                        new User("Jane Smith", "janesmith", "jane@example.com", "0987654321", "1985-05-15", Gender.Female, "98765432100", MaritalStatus.Married, Scholarship.Bachelor, "password456"),
                        new User("Alice Johnson", "alicej", "alice@example.com", "5555555555", "1992-03-20", Gender.Female, "11122233344", MaritalStatus.Single, Scholarship.Master, "password789"),
                        new User("Bob Brown", "bobb", "bob@example.com", "4444444444", "1988-07-30", Gender.Male, "22233344455", MaritalStatus.Divorced, Scholarship.None, "password321")
                    );
                    context.SaveChanges(); // Save changes after adding users
                }

                // Seed Addresses
                if (!context.Addresses.Any())
                {
                    var users = context.Users.ToList(); // Get all users to associate with addresses

                    context.Addresses.AddRange(
                        new Address("123 Main St", "1", "Downtown", "Cityville", "State", "12345", users[0]),
                        new Address("456 Elm St", "2", "Uptown", "Townsville", "State", "67890", users[1]),
                        new Address("789 Oak St", "3", "Midtown", "Villagetown", "State", "54321", users[2]),
                        new Address("321 Pine St", "4", "Suburbia", "Cityville", "State", "98765", users[3])
                    );
                    context.SaveChanges(); // Save changes after adding addresses
                }
            }
        }
    }
}

