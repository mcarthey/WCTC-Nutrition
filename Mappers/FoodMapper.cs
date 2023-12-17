using Nutrition.Entities;
using Nutrition.Models;

namespace Nutrition.Mappers
{
    public class FoodMapper : IFoodMapper
    {
        public FoodDto MapToDto(Food food)
        {
            if (food == null)
            {
                return null;
            }

            FoodDto foodDto = new FoodDto
            {
                FdcId = food.FdcId,
                Description = food.Description,
                // Map other properties as needed
                FoodNutrients = MapFoodNutrients(food.FoodNutrients),
                FoodMeasures = MapFoodMeasures(food.FoodMeasures),
                // Map other nested properties
            };

            return foodDto;
        }

        private List<FoodNutrientDto> MapFoodNutrients(List<FoodNutrient> foodNutrients)
        {
            if (foodNutrients == null)
            {
                return null;
            }

            return foodNutrients.Select(nutrient => new FoodNutrientDto
            {
                NutrientId = nutrient.NutrientId,
                NutrientName = nutrient.NutrientName,
                // Map other properties
            }).ToList();
        }

        private List<FoodMeasureDto> MapFoodMeasures(List<FoodMeasure> foodMeasures)
        {
            if (foodMeasures == null)
            {
                return null;
            }

            return foodMeasures.Select(measure => new FoodMeasureDto
            {
                DisseminationText = measure.DisseminationText,
                GramWeight = measure.GramWeight,
                // Map other properties
            }).ToList();
        }
        // Add other mapping methods for nested structures
    }
}
