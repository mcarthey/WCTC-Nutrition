using System.ComponentModel.DataAnnotations;

namespace Nutrition.Entities;

public class Nutrient
{
    [Key]
    public int NutrientId { get; set; } // Primary key
    public int FoodItemId { get; set; } // Foreign key
    public string Name { get; set; }
    public double Amount { get; set; }

    // Navigation property
    public FoodItem FoodItem { get; set; }
}