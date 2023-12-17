namespace Nutrition.Entities;

public class MealPlan
{
    public int PlanId { get; set; }
    public int UserId { get; set; }

    // Navigation property
    public List<PlanItem> PlanItems { get; set; }
}
