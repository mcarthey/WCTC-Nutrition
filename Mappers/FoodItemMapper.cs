using Nutrition.Entities;

namespace Nutrition.Mappers
{
    public class FoodItemMapper : IFoodItemMapper
    {
        public FoodItemDto Map(FoodItem foodItem)
        {
            return new FoodItemDto
            {
                Description = foodItem.Description,
                Nutrients = foodItem.Nutrients.Select(n => new NutrientDto
                {
                    Name = n.Name
                }).ToList()
            };
        }
    }
}
