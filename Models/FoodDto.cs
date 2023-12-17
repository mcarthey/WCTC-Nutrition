namespace Nutrition.Models;

public class FoodDto
{
    public int FdcId { get; set; }
    public string Description { get; set; }
    public List<FoodNutrientDto> FoodNutrients { get; set; }
    public List<FoodMeasureDto> FoodMeasures { get; set; }
    // Add other properties as needed
}
