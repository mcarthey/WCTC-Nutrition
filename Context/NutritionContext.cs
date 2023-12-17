using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nutrition.Entities;

namespace Nutrition.Context;

public class NutritionContext : DbContext
{
    // Add DbSet properties for your entities (Food, FoodNutrient, etc.)
    public DbSet<Food> FoodItems { get; set; }
    public DbSet<FoodNutrient> Nutrients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("NutritionContext")
        );
    }
}
