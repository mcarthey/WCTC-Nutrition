using System.ComponentModel.DataAnnotations;

namespace Nutrition.Entities
{
    public class FoodItem
    {
        public int FoodItemId { get; set; } // Primary key
        public string Description { get; set; }

        // Navigation property
        public List<Nutrient> Nutrients { get; set; }
        public List<PlanItem> PlanItems { get; set; }
    }


}
