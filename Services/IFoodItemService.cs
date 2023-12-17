using Nutrition.Entities;

public interface IFoodItemService
{
    FoodItemDto GetFoodItemDetails(string foodItem);
    Task<List<FoodItemDto>> GetFoodItemsFromUsda(string foodItem);
}
