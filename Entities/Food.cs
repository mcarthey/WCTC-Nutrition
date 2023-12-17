using System.ComponentModel.DataAnnotations;

namespace Nutrition.Entities
{
    public class Food
    {
        public int FdcId { get; set; }
        public string Description { get; set; }
        public string CommonNames { get; set; }
        public string AdditionalDescriptions { get; set; }
        public string DataType { get; set; }
        public int FoodCode { get; set; }
        public string PublishedDate { get; set; }
        public string FoodCategory { get; set; }
        public int FoodCategoryId { get; set; }
        public double Score { get; set; }
        public List<FoodNutrient> FoodNutrients { get; set; }
        public List<FoodMeasure> FoodMeasures { get; set; }
        // Add other properties as needed

        // You may want to include other nested classes like FoodNutrient, FoodMeasure, etc.
    }


}
