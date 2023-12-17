using Microsoft.EntityFrameworkCore;
using Nutrition.Context;

public class FoodItemService : IFoodItemService
{
    private readonly NutritionContext _context;

    public FoodItemService(NutritionContext context)
    {
        _context = context;
    }

    public FoodItem GetFoodItemDetails(string foodItem)
    {
        // Assume that FoodItem and Nutrient are EF entities
        var foodItemEntity = _context.FoodItems
            .Include(f => f.Nutrients)
            .FirstOrDefault(f => f.Description == foodItem);

        if (foodItemEntity == null)
        {
            // Food item not found in the database
            // You may want to handle this case based on your application logic
            return null;
        }

        // Map EF entities to DTOs (Data Transfer Objects) or use them directly in the UI
        var foodItemDto = new FoodItem
        {
            Description = foodItemEntity.Description,
            Nutrients = foodItemEntity.Nutrients.Select(n => new Nutrient
            {
                Name = n.Name,
                Value = n.Value,
                Unit = n.Unit
            }).ToList()
        };

        return foodItemDto;
    }
}
