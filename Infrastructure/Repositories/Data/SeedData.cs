﻿using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories.Data
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GabiniDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GabiniDbContext>>()))
            {
                // Seed Users
                if (!await context.Users.Any())
                {
                    await context.Users.AddRange(
                        new User("John Doe", "johndoe", "john@example.com", "1234567890", "1990-01-01", Gender.Male, "12345678901", MaritalStatus.Single, Scholarship.None, "password123"),
                        new User("Jane Smith", "janesmith", "jane@example.com", "0987654321", "1985-05-15", Gender.Female, "98765432100", MaritalStatus.Married, Scholarship.Bachelor, "password456"),
                        new User("Alice Johnson", "alicej", "alice@example.com", "5555555555", "1992-03-20", Gender.Female, "11122233344", MaritalStatus.Single, Scholarship.Master, "password789"),
                        new User("Bob Brown", "bobb", "bob@example.com", "4444444444", "1988-07-30", Gender.Male, "22233344455", MaritalStatus.Divorced, Scholarship.None, "password321")
                    );
                    await context.SaveChanges(); // Save changes after adding users
                }

                // Seed Addresses
                if (!await context.Addresses.Any())
                {
                    var users = await context.Users.ToList(); // Get all users to associate with addresses

                    await context.Addresses.AddRange(
                        new Address("123 Main St", "1", "Downtown", "Cityville", "State", "12345", users[0]),
                        new Address("456 Elm St", "2", "Uptown", "Townsville", "State", "67890", users[1]),
                        new Address("789 Oak St", "3", "Midtown", "Villagetown", "State", "54321", users[2]),
                        new Address("321 Pine St", "4", "Suburbia", "Cityville", "State", "98765", users[3])
                    );
                    await context.SaveChanges(); // Save changes after adding addresses
                }

                // Seed Categories
                if (!context.Categories.Any())
                {
                    await context.Categories.AddRange(
                        new Category("Category 1", "Description 1"),
                        new Category("Category 2", "Description 2"),
                        new Category("Category 3", "Description 3"),
                        new Category("Category 4", "Description 4")
                    );
                    await context.SaveChanges();
                }

                // Seed Products
                if (!await context.Products.Any())
                {
                    await context.Products.AddRange(
                        new Product("Product 1", "Description 1", 9.99m, 10, "/products/placeholder.svg", context.Categories.OrderBy(c => c.Id).Last()),
                        new Product("Product 2", "Description 2", 19.99m, 5, "/products/placeholder.svg", context.Categories.OrderBy(c => c.Id).Last()),
                        new Product("Product 3", "Description 3", 29.99m, 3, "/products/placeholder.svg", context.Categories.OrderBy(c => c.Id).First()),
                        new Product("Product 4", "Description 4", 39.99m, 2, "/products/placeholder.svg", context.Categories.OrderBy(c => c.Id).Last())
                    );
                    await context.SaveChanges();
                }
            }
        }
    }
}

