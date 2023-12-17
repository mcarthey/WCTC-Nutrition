using Nutrition.Models;

public interface IFoodItemService
{
    Task<FoodDto> GetFoodItemsFromUsda(string foodItem);
}
