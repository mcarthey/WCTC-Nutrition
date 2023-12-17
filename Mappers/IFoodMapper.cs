using Nutrition.Entities;
using Nutrition.Models;

namespace Nutrition.Mappers;

public interface IFoodMapper
{
    FoodDto MapToDto(Food food);
}
