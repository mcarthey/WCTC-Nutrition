using Nutrition.Entities;

namespace Nutrition.Requesters;

public interface IUsdaRequester
{
    Task<List<FoodItemDto>> Invoke(string searchString);
    Task<List<Food>> GetFoodItemFromUsda();
}
