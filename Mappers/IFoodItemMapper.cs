using Nutrition.Entities;

namespace Nutrition.Mappers;

public interface IFoodItemMapper
{
    FoodItemDto Map(Food food);
}
