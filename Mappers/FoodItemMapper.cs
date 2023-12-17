using Nutrition.Entities;

namespace Nutrition.Mappers
{
    public class FoodItemMapper : IFoodItemMapper
    {
        public FoodItemDto Map(Food food)
        {
            return new FoodItemDto
            {
                Description = food.Description,
                Nutrients = food.FoodNutrients.Select(n => new NutrientDto
                {
                    Name = n.NutrientName
                }).ToList()
            };
        }
    }
}
