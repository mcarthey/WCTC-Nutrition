namespace Nutrition.Models;

public class FoodDto
{
    public string Description { get; set; }
    public long FdcId { get; set; }
    public List<FoodMeasureDto> FoodMeasures { get; set; }

    public List<FoodNutrientDto> FoodNutrients { get; set; }
    // Add other properties as needed
}
