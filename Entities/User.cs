namespace Nutrition.Entities;

public class User
{
    // Navigation property
    public List<MealPlan> MealPlans { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
}
