using Nutrition.Entities;

namespace Nutrition.Models;

public class FoodNutrientDto
{
    public long NutrientId { get; set; }
    public string NutrientName { get; set; }

    public string NutrientUnit { get; set; }

    public double NutrientValue { get; set; }
    // Add other properties as needed
}
