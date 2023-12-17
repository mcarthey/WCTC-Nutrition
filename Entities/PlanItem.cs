namespace Nutrition.Entities;

public class PlanItem
{
    public int PlanItemId { get; set; }
    public int PlanId { get; set; }
    public int FoodItemId { get; set; }

    // Navigation properties
    public FoodItem FoodItem { get; set; }
    public MealPlan MealPlan { get; set; }
}
