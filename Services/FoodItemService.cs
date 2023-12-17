using Microsoft.EntityFrameworkCore;
using Nutrition.Context;
using Nutrition.Entities;
using Nutrition.Requesters;

public class FoodItemService : IFoodItemService
{
    private readonly NutritionContext _context;
    private readonly IUsdaRequester _usdaRequester;
    private string _foodItem;

    public FoodItemService(NutritionContext context, IUsdaRequester usdaRequester)
    {
        _context = context;
        _usdaRequester = usdaRequester;
    }

    public async Task<List<FoodItemDto>> GetFoodItemsFromUsda(string foodItem)
    {
        _foodItem = foodItem;

        var results = await _usdaRequester.Invoke(_foodItem);

        return results;
    }

    public FoodItemDto GetFoodItemDetails(string foodItem)
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
        var foodItemDto = new FoodItemDto
        {
            Description = foodItemEntity.Description,
            Nutrients = foodItemEntity.Nutrients.Select(n => new NutrientDto
            {
                Name = n.Name,
                Value = n.Amount,
                Unit = n.NutrientId.ToString()
            }).ToList()
        };

        return foodItemDto;
    }
}
