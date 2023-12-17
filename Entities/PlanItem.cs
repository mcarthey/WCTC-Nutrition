namespace Nutrition.Entities;

public class PlanItem
{
    public int FoodItemId { get; set; }

    // Navigation properties
    public MealPlan MealPlan { get; set; }
    public int PlanId { get; set; }
    public int PlanItemId { get; set; }
}
