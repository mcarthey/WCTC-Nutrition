using Microsoft.EntityFrameworkCore;
using Nutrition.Context;
using Nutrition.Entities;
using Nutrition.Models;
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

    public async Task<FoodDto> GetFoodItemsFromUsda(string foodItem)
    {
        _foodItem = foodItem;

        var results = await _usdaRequester.Invoke(_foodItem);

        return results;
    }
}
