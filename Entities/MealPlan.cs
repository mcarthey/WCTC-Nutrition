namespace Nutrition.Entities;

public class MealPlan
{
    public int MealPlanId { get; set; }
    public int UserId { get; set; }

    // Navigation property
    public List<PlanItem> PlanItems { get; set; }
}
