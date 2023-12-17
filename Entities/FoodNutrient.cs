using System.ComponentModel.DataAnnotations;

namespace Nutrition.Entities;

public class FoodNutrient
{
    public int NutrientId { get; set; }
    public string NutrientName { get; set; }
    public string NutrientNumber { get; set; }
    public string UnitName { get; set; }
    public double Value { get; set; }
    public int Rank { get; set; }
    public int IndentLevel { get; set; }
    public int FoodNutrientId { get; set; }

    // Add other properties as needed
}