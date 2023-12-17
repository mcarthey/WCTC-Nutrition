namespace Nutrition.Entities;

public class PlanItem
{
    public int PlanItemId { get; set; }
    public int PlanId { get; set; }
    public int FoodItemId { get; set; }

    // Navigation properties
    public Food Food { get; set; }
    public MealPlan MealPlan { get; set; }
}
