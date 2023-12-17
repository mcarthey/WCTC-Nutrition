namespace Nutrition.Entities;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }

    // Navigation property
    public List<MealPlan> MealPlans { get; set; }
}
